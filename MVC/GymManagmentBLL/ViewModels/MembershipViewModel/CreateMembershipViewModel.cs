using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagmentBLL.ViewModels.MembershipViewModel
{
    public class CreateMembershipViewModel
    {
        public int MemberId { get; set; }
        public int PlanId { get; set; }
        // You can add logic to calculate EndDate based on the Plan's duration
        public DateTime StartDate { get; set; } = DateTime.Now;
    }
}
