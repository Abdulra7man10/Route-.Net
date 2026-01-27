using GymManagmentBLL.Services.Interfaces;
using GymManagmentBLL.ViewModels.AnalyticsViewModel;
using GymManagmentDAL.Entities;
using GymManagmentDAL.Repostories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagmentBLL.Services.Classes
{
    public class AnalyticsService : IAnalyticsService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AnalyticsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public AnalaticsViewModel GetAnalutiysData()
        {
            var Sessions = _unitOfWork.GetRepository<Session>().GetAll();

            return new AnalaticsViewModel
            {
                ActiveMembers = _unitOfWork.GetRepository<Membership>().GetAll(X => X.Status == "Active").Count(),
                TotalMembers = _unitOfWork.GetRepository<Member>().GetAll().Count(),
                TotalTrainer = _unitOfWork.GetRepository<Trainer>().GetAll().Count(),
                UpcomingSessions = Sessions.Where(X => X.StartDate > DateTime.Now).Count(),
                OngoingSession = Sessions.Where(X => X.StartDate <= DateTime.Now && X.EndDate >= DateTime.Now).Count(),
                CompleteSession = Sessions.Where(X => X.EndDate < DateTime.Now).Count(),

            };

        }
    }
}
