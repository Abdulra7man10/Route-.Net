using GymManagmentDAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymManagmentDAL.Repostories.Interfaces;
using GymManagmentDAL.Data.Context;
using GymManagmentDAL.Entities;

namespace GymManagmentDAL.Repostories.Classes
{
    public class MemberRepostory : GenericRepostory<Member>
    {
        private readonly GymDBContext _context;
        public MemberRepostory(GymDBContext context) : base(context)
        {
            _context = context;
        }

        //public IEnumerable<Member> GetAll() => _context.Members.ToList();
        //public Member? GetById(int id) => _context.Members.Find(id);

        //public int Add(Member member)
        //{
        //    _context.Members.Add(member);
        //    return _context.SaveChanges();
        //}
        //public int Update(Member member)
        //{
        //    _context.Members.Update(member);
        //    return _context.SaveChanges();
        //}
        //public int Delete(int id)
        //{
        //    var member = _context.Members.Find(id);
        //    if (member is not null)
        //    {
        //        _context.Members.Remove(member);
        //        return _context.SaveChanges();
        //    }
        //    return 0;
        //}
    }
}
