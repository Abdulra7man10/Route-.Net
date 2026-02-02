using GymManagmentBLL.ViewModels.MembershipViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagmentBLL.Service.Interfaces
{
    public interface IMembershipService
    {
        bool Subscribe(CreateMembershipViewModel model);
        IEnumerable<MembershipViewModel> GetAllMemberships();
        //bool CancelMembership(int id);
    }
}
