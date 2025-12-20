using GymManagmentDAL.Data.Context;
using GymManagmentDAL.Entities;
using GymManagmentDAL.Repostories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace GymManagmentDAL.Repostories.Classes
{
    public class SessionRepostory : ISessionRepostory
    {
        private readonly GymDBContext _context = new GymDBContext(); 
        public IEnumerable<Session> GetAll() => _context.Sessions.ToList();
        public Session? GetById(int id) => _context.Sessions.Find(id);

        public int Add(Session session)
        {
            _context.Sessions.Add(session);
            return _context.SaveChanges();
        }
        public int Update(Session session)
        {
            _context.Sessions.Update(session);
            return _context.SaveChanges();
        }
        public int Delete(int id)
        {
            var session = _context.Sessions.Find(id);
            if (session is not null)
            {
                _context.Sessions.Remove(session);
                return _context.SaveChanges();
            }
            return 0;
        }
    }
}
