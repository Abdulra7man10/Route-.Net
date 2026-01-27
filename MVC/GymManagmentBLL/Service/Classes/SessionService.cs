using GymManagmentBLL.Service.Interfaces;
using GymManagmentBLL.ViewModels.SessionViewModel;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymManagmentDAL.Repostories.Interfaces;
using GymManagmentDAL.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Storage;

namespace GymManagmentBLL.Service.Classes
{
    public class SessionService : ISessionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public SessionService(IUnitOfWork unitOfWork, IMapper mapper) 
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public bool CreateSession(CreateSessionViewModel createSessionViewModel)
        {
            try
            {
                // logic
                if (!IsTrainerExist(createSessionViewModel.TrainerId))
                    return false;
                if (!IsCategoryExist(createSessionViewModel.CategoryId))
                    return false;
                if (!IsDateTimeValid(createSessionViewModel.StartDate, createSessionViewModel.EndDate))
                    return false;
                if (createSessionViewModel.Capacity > 25 || createSessionViewModel.Capacity < 0)
                    return false;

                // mapping
                var MappedSession = _mapper.Map<Session>(createSessionViewModel);

                // main logic with saving
                _unitOfWork.GetRepository<Session>().Add(MappedSession);
                return _unitOfWork.SaveChange() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Create Session Failed {ex}");
                return false;
            }
        }

        public IEnumerable<SessionViewModel> GetAllSessions()
        {
            var sessions = _unitOfWork.sessionRepository.GetAllSessionWithTrainerAndCategory();
            if (!sessions.Any())
                return [];

            //return sessions.Select(s => new SessionViewModel
            //{
            //    Id = s.Id,
            //    Description = s.Description,
            //    StartDate = s.StartDate,
            //    EndDate = s.EndDate,
            //    Capacity = s.Capacity,
            //    TrainerName = s.SessionTrainer.Name,
            //    CategoryName = s.SessionCategory.CategoryName.ToString(),
            //    AvailableSlots = s.Capacity - _unitOfWork.sessionRepository.GetCountOfBookedSlot(s.Id)
            //}).ToList();
            var MappedSession = _mapper.Map<IEnumerable<Session>, IEnumerable<SessionViewModel>>(sessions);
            foreach (var session in MappedSession) {
                session.AvailableSlots = session.Capacity - _unitOfWork.sessionRepository.GetCountOfBookedSlot(session.Id);
            }
            return MappedSession;
        }

        public SessionViewModel? GetSessionById(int id)
        {
            var session = _unitOfWork.sessionRepository.GetSessionWithTrainerAndCategory(id);
            if (session is null)
                return null;

            // Manual Mapping
            //return new SessionViewModel
            //{
            //    Description = session.Description,
            //    StartDate = session.StartDate,
            //    EndDate = session.EndDate,
            //    TrainerName = session.SessionTrainer.Name,
            //    CategoryName = session.SessionCategory.CategoryName.ToString(),
            //    AvailableSlots = session.Capacity - _unitOfWork.sessionRepository.GetCountOfBookedSlot(session.Id)
            //};

            var MappedSession = _mapper.Map<Session, SessionViewModel>(session);
            MappedSession.AvailableSlots = MappedSession.Capacity - _unitOfWork.sessionRepository.GetCountOfBookedSlot(MappedSession.Id); // because you ignore it in profile mapping
            return MappedSession;
        }

        public UpdateSessionViewModel? GetSessionToUpdate(int sessionId)
        {
            var session = _unitOfWork.sessionRepository.GetById(sessionId);
            if (!IsSessionAvailableToUpdate(session!))
                return null;
            return _mapper.Map<UpdateSessionViewModel>(session);
        }

        public bool UpdateSession(int sessionId, UpdateSessionViewModel updateSession)
        {
            try 
            {
                var session = _unitOfWork.sessionRepository.GetById(sessionId);
                if (!IsSessionAvailableToUpdate(session!)) return false;
                if (!IsTrainerExist(updateSession.TrainerId)) return false;
                if (!IsDateTimeValid(updateSession.StartDate, updateSession.EndDate)) return false;

                _mapper.Map<UpdateSessionViewModel>(session);
                session!.UpdatedAt = DateTime.Now;

                _unitOfWork.GetRepository<Session>().Update(session);
                return _unitOfWork.SaveChange() > 0;
            }
            catch (Exception ex) 
            {
                Console.WriteLine($"Update Session Failed {ex}");
                return false;
            }
        }

        public bool RemoveSession(int sessionId)
        {
            try
            {
                var session = _unitOfWork.sessionRepository.GetById(sessionId);
                if (!IsSessionAvailableForRemoving(session!)) return false;
                
                _unitOfWork.sessionRepository.Delete(session!);
                return _unitOfWork.SaveChange() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Remove Session failed {ex}");
                return false;
            }
        }

        public IEnumerable<TrainerSelectViewModel> GetTrainerForDropDown()
        {
            var trainer = _unitOfWork.GetRepository<Trainer>().GetAll();
            return _mapper.Map<IEnumerable<TrainerSelectViewModel>>(trainer);
        }

        public IEnumerable<CategorySelectViewModel> GetCategoryForDropDown()
        {
            var category = _unitOfWork.GetRepository<Category>().GetAll();
            return _mapper.Map<IEnumerable<CategorySelectViewModel>>(category);
        }

        #region helpers
        private bool IsTrainerExist(int TrainerId) 
        {
            return _unitOfWork.GetRepository<Trainer>().GetById(TrainerId) != null;
        }

        private bool IsCategoryExist(int CategoryId)
        {
            return _unitOfWork.GetRepository<Category>().GetById(CategoryId) != null;
        }

        private bool IsDateTimeValid(DateTime startDate, DateTime endDate)
        {
            return startDate < endDate;
        }

        private bool IsSessionAvailableToUpdate(Session session)
        {
            if (session is null ) return false;
            if (session.EndDate < DateTime.Now) return false;
            if (session.StartDate <= DateTime.Now) return false;

            var hasActiveBooking = _unitOfWork.sessionRepository.GetCountOfBookedSlot(session.Id) > 0;
            if (hasActiveBooking) return false;

            return true;
        }

        private bool IsSessionAvailableForRemoving(Session session)
        {
            if ( session is null ) return false;

            // if started
            if (session.StartDate <= DateTime.Now && DateTime.Now < session.EndDate) return false;

            // if upcoming
            if (session.StartDate > DateTime.Now) return false; // may comment this for flexible editing

            // if session have active booking
            var hasActiveBooking = _unitOfWork.sessionRepository.GetCountOfBookedSlot(session.Id) > 0;
            if (!hasActiveBooking) return false;

            return true;
        }
        #endregion
    }
}
