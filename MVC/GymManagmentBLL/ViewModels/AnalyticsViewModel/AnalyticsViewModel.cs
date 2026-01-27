using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagmentBLL.ViewModels.AnalyticsViewModel
{
    public class AnalaticsViewModel
    {
        public int TotalMembers { get; set; }
        public int ActiveMembers { get; set; }
        public int TotalTrainer { get; set; }
        public int UpcomingSessions { get; set; }
        public int OngoingSession { get; set; }

        public int CompleteSession { get; set; }
    }
}
