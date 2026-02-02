using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagmentBLL.ViewModels.SessionScheduleViewModel
{
    public class SessionScheduleViewModel
    {
        public int Id { get; set; }
        public string MemberName { get; set; } = null!;
        public string SessionDescription { get; set; } = null!;
        public string TrainerName { get; set; } = null!;
        public string StartTime { get; set; } = null!;
        public bool IsAttended { get; set; }
    }
}
