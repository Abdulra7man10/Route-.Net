using GymManagmentBLL.Service.Interfaces;
using GymManagmentBLL.ViewModels.SessionScheduleViewModel;
using GymManagmentDAL.Entities;
using GymManagmentDAL.Repostories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GymManagmentPL.Controllers
{
    public class SessionScheduleController : Controller
    {
        private readonly ISessionScheduleService _scheduleService;
        private readonly IUnitOfWork _unitOfWork;

        public SessionScheduleController(ISessionScheduleService scheduleService, IUnitOfWork unitOfWork)
        {
            _scheduleService = scheduleService;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var bookings = _scheduleService.GetAllBookings();
            return View(bookings);
        }

        public IActionResult Book()
        {
            ViewBag.Members = new SelectList(_unitOfWork.GetRepository<GymManagmentDAL.Entities.Member>().GetAll(), "Id", "Name");
            ViewBag.Sessions = new SelectList(_unitOfWork.GetRepository<Session>().GetAll(s => s.StartDate > DateTime.Now), "Id", "Description");
            return View(new CreateSessionScheduleViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Book(CreateSessionScheduleViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Members = new SelectList(_unitOfWork.GetRepository<GymManagmentDAL.Entities.Member>().GetAll(), "Id", "Name");
                ViewBag.Sessions = new SelectList(_unitOfWork.GetRepository<Session>().GetAll(), "Id", "Description");
                return View(model);
            }

            var result = _scheduleService.BookSession(model);
            if (result)
            {
                TempData["SuccessMessage"] = "Session booked successfully!";
                return RedirectToAction(nameof(Index));
            }

            TempData["ErrorMessage"] = "Failed to book session. It might be full or the member is already registered.";
            return RedirectToAction(nameof(Book));
        }

        [HttpPost]
        public IActionResult Cancel(int id)
        {
            var result = _scheduleService.CancelBooking(id);
            if (result)
                TempData["SuccessMessage"] = "Booking cancelled successfully.";
            else
                TempData["ErrorMessage"] = "Could not cancel booking.";

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult ToggleAttendance(int id)
        {
            var result = _scheduleService.ToggleAttendance(id);
            if (result)
                TempData["SuccessMessage"] = "Attendance updated!";
            else
                TempData["ErrorMessage"] = "Failed to update attendance.";

            return RedirectToAction(nameof(Index));
        }
    }
}