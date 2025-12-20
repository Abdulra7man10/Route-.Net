using GymManagmentDAL.Data.Context;
using GymManagmentDAL.Entities;
using GymManagmentDAL.Repostories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagmentDAL.Repostories.Classes
{
    public class MembershipRepository : GenericRepostory<Membership>
    {
        private readonly GymDBContext _context;
        public MembershipRepository(GymDBContext context) : base(context)
        {
            _context = context;
        }

        //public IEnumerable<Membership> GetAll() => _context.Memberships.ToList();
        //public Membership? GetById(int id) => _context.Memberships.Find(id);
        //public int Add(Membership entity) { _context.Memberships.Add(entity); return _context.SaveChanges(); }
        //public int Update(Membership entity) { _context.Memberships.Update(entity); return _context.SaveChanges(); }
        //public int Delete(int id)
        //{
        //    var item = _context.Memberships.Find(id);
        //    if (item != null) { _context.Memberships.Remove(item); return _context.SaveChanges(); }
        //    return 0;
        //}
    }
}
