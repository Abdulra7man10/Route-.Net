using AutoMapper;
using GymManagmentBLL.Service.Interfaces;
using GymManagmentBLL.ViewModels.MembershipViewModel;
using GymManagmentDAL.Entities;
using GymManagmentDAL.Repostories.Interfaces;

namespace GymManagmentBLL.Service.Classes
{
    public class MembershipService : IMembershipService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MembershipService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public bool Subscribe(CreateMembershipViewModel model)
        {
            try
            {
                var plan = _unitOfWork.GetRepository<Plan>().GetById(model.PlanId);
                if (plan == null) return false;

                var membership = new Membership
                {
                    MemberId = model.MemberId,
                    PlanId = model.PlanId,
                    CreatedAt = model.StartDate,
                    EndDate = model.StartDate.AddDays(plan.DurationDays)
                };

                // 3. Save
                _unitOfWork.GetRepository<Membership>().Add(membership);
                return _unitOfWork.SaveChange() > 0;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<MembershipViewModel> GetAllMemberships()
        {
            // Use Include/Join via Repository if your Generic Repo supports it, 
            // otherwise, fetch and map manually for clarity.
            var memberships = _unitOfWork.GetRepository<Membership>().GetAll();

            return memberships.Select(m => new MembershipViewModel
            {
                Id = m.Id,
                MemberName = _unitOfWork.GetRepository<GymManagmentDAL.Entities.Member>().GetById(m.MemberId)?.Name,
                PlanName = _unitOfWork.GetRepository<Plan>().GetById(m.PlanId)?.Name,
                Status = m.Status,
                StartDate = m.CreatedAt.ToShortDateString(),
                EndDate = m.EndDate.ToShortDateString()
            }).ToList();
        }

        //public bool CancelMembership(int id)
        //{
        //    var repo = _unitOfWork.GetRepository<Membership>();
        //    var membership = repo.GetById(id);
        //    if (membership == null) return false;

        //    repo.Update(membership);
        //    return _unitOfWork.SaveChange() > 0;
        //}
    }
}