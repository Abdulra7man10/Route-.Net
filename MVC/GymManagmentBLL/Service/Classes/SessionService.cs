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

namespace GymManagmentBLL.Service.Classes
{
    public class SessionService : ISessionService
    {
        private readonly IUnitOfWork _unitOfWork;
        public SessionService(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<SessionViewModel> GetAllSessions()
        {
            var sessions = _unitOfWork.sessionRepository.GetAllSessionWithTrainerAndCategory();
            if (!sessions.Any())
                return [];

            return sessions.Select(s => new SessionViewModel
            {
                Id = s.Id,
                Description = s.Description,
                StartDate = s.StartDate,
                EndDate = s.EndDate,
                Capacity = s.Capacity,
                TrainerName = s.SessionTrainer.Name,
                CategoryName = s.SessionCategory.CategoryName.ToString(),
                AvailableSlots = s.Capacity - _unitOfWork.sessionRepository.GetCountOfBookedSlot(s.Id)
            }).ToList();
        }
    }
}
