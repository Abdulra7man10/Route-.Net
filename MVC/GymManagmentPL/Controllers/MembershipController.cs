using GymManagmentBLL.Service.Interfaces;
using GymManagmentBLL.ViewModels.MembershipViewModel;
using GymManagmentDAL.Entities;
using GymManagmentDAL.Repostories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GymManagmentPL.Controllers
{
    public class MembershipController : Controller
    {
        private readonly IMembershipService _membershipService;
        private readonly IUnitOfWork _unitOfWork;

        public MembershipController(IMembershipService membershipService, IUnitOfWork unitOfWork)
        {
            _membershipService = membershipService;
            _unitOfWork = unitOfWork;
        }

        // GET: Membership/Index
        public IActionResult Index()
        {
            var memberships = _membershipService.GetAllMemberships();
            return View(memberships);
        }

        // GET: Membership/Subscribe
        public IActionResult Subscribe()
        {
            // Populate Dropdowns for the View
            var members = _unitOfWork.GetRepository<GymManagmentDAL.Entities.Member>().GetAll();
            var plans = _unitOfWork.GetRepository<Plan>().GetAll();

            ViewBag.Members = new SelectList(members, "Id", "Name");
            ViewBag.Plans = new SelectList(plans, "Id", "Name");

            return View(new CreateMembershipViewModel());
        }

        // POST: Membership/Subscribe
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Subscribe(CreateMembershipViewModel model)
        {
            if (!ModelState.IsValid)
            {
                // Re-populate dropdowns if validation fails
                ViewBag.Members = new SelectList(_unitOfWork.GetRepository<GymManagmentDAL.Entities.Member>().GetAll(), "Id", "Name");
                ViewBag.Plans = new SelectList(_unitOfWork.GetRepository<Plan>().GetAll(), "Id", "Name");
                return View(model);
            }

            var result = _membershipService.Subscribe(model);

            if (result)
            {
                TempData["SuccessMessage"] = "Subscription activated successfully!";
                return RedirectToAction(nameof(Index));
            }

            TempData["ErrorMessage"] = "Failed to activate subscription. Please check if the member already has an active plan.";

            ViewBag.Members = new SelectList(_unitOfWork.GetRepository<GymManagmentDAL.Entities.Member>().GetAll(), "Id", "Name");
            ViewBag.Plans = new SelectList(_unitOfWork.GetRepository<Plan>().GetAll(), "Id", "Name");
            return View(model);
        }

        //[HttpPost]
        //public IActionResult Cancel(int id)
        //{
        //    var result = _membershipService.CancelMembership(id);
        //    if (result)
        //    {
        //        TempData["SuccessMessage"] = "Membership cancelled successfully.";
        //    }
        //    else
        //    {
        //        TempData["ErrorMessage"] = "Could not cancel membership.";
        //    }

        //    return RedirectToAction(nameof(Index));
        //}

        public IActionResult Details(int id)
        {
            if (id < 0) return RedirectToAction(nameof(Index));
            // Fetch single membership and map to the ViewModel
            var membership = _unitOfWork.GetRepository<Membership>().GetById(id);
            if (membership == null) return NotFound();

            var model = new MembershipViewModel
            {
                Id = membership.Id,
                MemberName = _unitOfWork.GetRepository<GymManagmentDAL.Entities.Member>().GetById(membership.MemberId)?.Name,
                PlanName = _unitOfWork.GetRepository<Plan>().GetById(membership.PlanId)?.Name,
                Status = membership.Status,
                StartDate = membership.CreatedAt.ToShortDateString(),
                EndDate = membership.EndDate.ToShortDateString()
            };

            return View(model);
        }
    }
}