using GymManagmentDAL.Entities;

namespace GymManagmentDAL.Entities
{
    public class Member : GymUser
    {
        // JoinDate == CreatedAt from BaseEntity
        public string Photo { get; set; } = null!;

        #region Member-Session
        public HealthRecord HealthRecord { get; set; } = null!;
        #endregion

        #region Member-Membership
        public ICollection<Membership> Memberships { get; set; } = null!;
        #endregion

        #region Member-MemberSession
        public ICollection<MemberSession> MemberSessions { get; set; } = null!;
        #endregion
    }
}
