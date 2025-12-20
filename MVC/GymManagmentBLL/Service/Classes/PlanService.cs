using GymManagmentBLL.Service.Interfaces;
using GymManagmentBLL.ViewModels.PlanViewModel;
using GymManagmentDAL.Entities;
using GymManagmentDAL.Repostories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagmentBLL.Service.Classes
{
    public class PlanService : IPlanService
    {
        private readonly IUnitOfWork _unitOfWork;
        public PlanService(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }


        public IEnumerable<PlanViewModel> GetAllPlans()
        {
            var plans = _unitOfWork.GetRepository<Plan>().GetAll();
            if (plans == null || !plans.Any())
                return [];

            return plans.Select(p => new PlanViewModel
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                DurationDays = p.DurationDays,
                Description = p.Description,
                IsActive = p.IsActive
            }).ToList();
        }

        public PlanViewModel? GetPlanById(int id)
        {
            var plan = _unitOfWork.GetRepository<Plan>().GetById(id);
            if (plan is null)
                return null;
            return new PlanViewModel()
            {
                Id = plan.Id,
                Name = plan.Name,
                Price = plan.Price,
                DurationDays = plan.DurationDays,
                Description = plan.Description,
                IsActive = plan.IsActive
            };
        }

        public UpdatePlanViewModel? GetPlanToUpdate(int id)
        {
            var plan = _unitOfWork.GetRepository<Plan>().GetById(id);
            if (plan is null || HasActiveMembership(id))
                return null;

            return new UpdatePlanViewModel()
            {
                PlanName = plan.Name,
                Price = plan.Price,
                DurationDays = plan.DurationDays,
                Description = plan.Description
            };
        }
        
        public bool UpdatePlan(int id, UpdatePlanViewModel planToUpdate)
        {
            var plan = _unitOfWork.GetRepository<Plan>().GetById(id);
            if (plan is null || HasActiveMembership(id))
                return false;

            (plan.Description, plan.Name, plan.DurationDays, plan.Price) = 
                (planToUpdate.Description, planToUpdate.PlanName, planToUpdate.DurationDays, planToUpdate.Price);

            _unitOfWork.GetRepository<Plan>().Update(plan);
            return _unitOfWork.SaveChange() > 0;
        }

        public bool ToggleStatus(int id)
        {
            var planRepo = _unitOfWork.GetRepository<Plan>();

            var plan = planRepo.GetById(id);
            if (plan is null || HasActiveMembership(id))
                return false;

            plan.IsActive = !plan.IsActive; // switch status
            plan.UpdatedAt = DateTime.Now;
            try 
            {
                planRepo.Update(plan);
                return _unitOfWork.SaveChange() > 0;
            }
            catch 
            {
                return false;
            }
        }

        #region Helper
        private bool HasActiveMembership(int planId)
        {
            var activeMemberships = _unitOfWork.GetRepository<Membership>().GetAll(m => m.PlanId == planId && m.Status == "Active");
            return activeMemberships.Any();
        }
        #endregion

    }
}
