using GymManagmentDAL.Data.Context;
using GymManagmentDAL.Entities;
using GymManagmentDAL.Repostories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymManagmentDAL.Data.Context;
using GymManagmentDAL.Entities;
using GymManagmentDAL.Repostories.Interfaces;

namespace GymManagmentDAL.Repostories.Classes
{
    public class MemberSessionRepository : GenericRepostory<MemberSession>
    {
        private readonly GymDBContext _context;
        public MemberSessionRepository(GymDBContext context) : base(context)
        {
            _context = context;
        }

        //public IEnumerable<MemberSession> GetAll() => _context.MemberSessions.ToList();
        //public MemberSession? GetById(int id) => _context.MemberSessions.Find(id);
        //public int Add(MemberSession entity) { _context.MemberSessions.Add(entity); return _context.SaveChanges(); }
        //public int Update(MemberSession entity) { _context.MemberSessions.Update(entity); return _context.SaveChanges(); }
        //public int Delete(int id)
        //{
        //    var item = _context.MemberSessions.Find(id);
        //    if (item != null) { _context.MemberSessions.Remove(item); return _context.SaveChanges(); }
        //    return 0;
        //}
    }
}
