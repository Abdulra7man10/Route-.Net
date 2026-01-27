using GymManagmentBLL.ViewModels.TrainerViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagmentBLL.Service.Interfaces
{
    public interface ITrainerService
    {
        IEnumerable<TrainerViewModel> GetAllTrainers();
        bool CreateTrainer(CreateTrainerViewModel createTrainerViewModel);

        TrainerViewModel? GetTrainerDetails(int id);
        TrainerToUpdateViewModel? GetTrainerToUpdate(int TrainerId);

        bool UpdateTrainer(int TrainerId, TrainerToUpdateViewModel trainerToUpdate);

        bool RemoveTrainer(int TrainerId);
    }
}
