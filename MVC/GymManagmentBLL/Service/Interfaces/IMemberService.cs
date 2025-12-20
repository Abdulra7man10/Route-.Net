using GymManagmentBLL.ViewModels.MemberViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagmentBLL.Service.Interfaces
{
    public interface IMemberService
    {
        IEnumerable<MemberViewModels> GetAllMembers();
        bool CreateMember(CreateMemberViewModel createMemberViewModel);

        MemberViewModels? GetMemberDetails(int id);
        HealthRecordViewModel? GetMemberHealthRecordDetails(int MemberId);

        MemberToUpdateViewModel? GetMemberToUpdate(int MemberId);

        bool UpdateMember(int MemberId, MemberToUpdateViewModel memberToUpdate);

        bool RemoveMember(int MemberId);
    }
}
