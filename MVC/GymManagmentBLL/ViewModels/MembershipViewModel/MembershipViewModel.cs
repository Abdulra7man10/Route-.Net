using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagmentBLL.ViewModels.MembershipViewModel
{
    public class MembershipViewModel
    {
        public int Id { get; set; }
        public string MemberName { get; set; } = null!;
        public string PlanName { get; set; } = null!;
        public string Status { get; set; } = null!;
        public string StartDate { get; set; } = null!;
        public string EndDate { get; set; } = null!;
    }
}
