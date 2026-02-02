using GymManagmentBLL.ViewModels.SessionScheduleViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagmentBLL.Service.Interfaces
{
    public interface ISessionScheduleService
    {
        bool BookSession(CreateSessionScheduleViewModel model);
        IEnumerable<SessionScheduleViewModel> GetMemberSchedule(int memberId);
        IEnumerable<SessionScheduleViewModel> GetAllBookings();
        bool CancelBooking(int bookingId);
        bool ToggleAttendance(int bookingId);
    }
}
