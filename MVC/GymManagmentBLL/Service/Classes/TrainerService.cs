using GymManagmentBLL.Service.Interfaces;
using GymManagmentBLL.ViewModels.MemberViewModel;
using GymManagmentBLL.ViewModels.TrainerViewModel;
using GymManagmentDAL.Entities;
using GymManagmentDAL.Repostories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagmentBLL.Service.Classes
{
    public class TrainerService : ITrainerService
    {
        private readonly IUnitOfWork _unitOfWork;
        public TrainerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<TrainerViewModel> GetAllTrainers()
        {
            var trainers = _unitOfWork.GetRepository<Trainer>().GetAll();

            if (trainers is null || !trainers.Any())
                return [];

            var trainerViewModel = trainers.Select(t => new TrainerViewModel
            {
                Id = t.Id,
                Name = t.Name,
                Email = t.Email,
                Phone = t.Phone,
                Specialization = t.Specialies.ToString()
            });
            
            return trainerViewModel;
        }

        public bool CreateTrainer(CreateTrainerViewModel createTrainerViewModel)
        {
            try
            {
                if (IsEmailExist(createTrainerViewModel.Email) || IsPhoneExist(createTrainerViewModel.Phone))
                    return false;

                var trainer = new Trainer
                {
                    Name = createTrainerViewModel.Name,
                    Email = createTrainerViewModel.Email,
                    Phone = createTrainerViewModel.Phone,
                    Gender = createTrainerViewModel.Gender,
                    Specialies = createTrainerViewModel.Specialies,
                    DateOfBirth = createTrainerViewModel.DateOfBirth,
                    Address = new Address
                    {
                        BuildingNumber = createTrainerViewModel.BuildingNumber,
                        Street = createTrainerViewModel.Street,
                        City = createTrainerViewModel.City
                    }
                };

                _unitOfWork.GetRepository<Trainer>().Add(trainer);
                return _unitOfWork.SaveChange() > 0;
            }
            catch
            {
                return false;
            }
        }

        public TrainerViewModel? GetTrainerDetails(int id)
        {
            var trainer = _unitOfWork.GetRepository<Trainer>().GetById(id);
            if (trainer is null)
                return null;

            var trainerViewModel = new TrainerViewModel
            {
                Id = trainer.Id,
                Name = trainer.Name,
                Email = trainer.Email,
                Phone = trainer.Phone,
                Specialization = trainer.Specialies.ToString(),
                DateOfBirth = trainer.DateOfBirth.ToString("MM/dd/yyyy"),
                Address = trainer.Address != null ? $"{trainer.Address.BuildingNumber}, {trainer.Address.Street}, {trainer.Address.City}" : null
            };

            return trainerViewModel;
        }

        public TrainerToUpdateViewModel? GetTrainerToUpdate(int TrainerId)
        {
            var trainer = _unitOfWork.GetRepository<Trainer>().GetById(TrainerId);
            if (trainer is null)
                return null;

            return new TrainerToUpdateViewModel()
            {
                Name = trainer.Name,
                Email = trainer.Email,
                Phone = trainer.Phone,
                BuildingNumber = trainer.Address.BuildingNumber,
                Street = trainer.Address.Street,
                City = trainer.Address.City,
                Specialies = trainer.Specialies
            };
        }

        public bool UpdateTrainer(int TrainerId, TrainerToUpdateViewModel trainerToUpdate)
        {
            try
            {
                if (IsEmailExist(trainerToUpdate.Email) || IsPhoneExist(trainerToUpdate.Phone))
                    return false;

                var trainerRepo = _unitOfWork.GetRepository<Trainer>();
                var trainer = trainerRepo.GetById(TrainerId);
                if (trainer is null)
                    return false;

                trainer.Email = trainerToUpdate.Email;
                trainer.Phone = trainerToUpdate.Phone;
                trainer.Address.City = trainerToUpdate.City;
                trainer.Address.Street = trainerToUpdate.Street;
                trainer.Address.BuildingNumber = trainerToUpdate.BuildingNumber;
                trainer.Specialies = trainerToUpdate.Specialies;
                trainer.UpdatedAt = DateTime.Now;

                trainerRepo.Update(trainer);
                return _unitOfWork.SaveChange() > 0;
            }
            catch
            {
                return false;
            }
        }

        public bool RemoveTrainer(int TrainerId)
        {
            var trainerRepo = _unitOfWork.GetRepository<Trainer>();

            var trainer = trainerRepo.GetById(TrainerId);
            if (trainer is null)
                return false;

            // no need for BLogic, trainer is optional with session only

            trainerRepo.Delete(trainer);
            return _unitOfWork.SaveChange() > 0;
        }

        #region Helper methods
        private bool IsEmailExist(string email)
        {
            return _unitOfWork.GetRepository<Trainer>().GetAll(x => x.Email == email).Any();
        }

        private bool IsPhoneExist(string phone)
        {
            return _unitOfWork.GetRepository<Trainer>().GetAll(x => x.Phone == phone).Any();
        }
        #endregion
    }
}
