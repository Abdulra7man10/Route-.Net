using GymManagmentDAL.Repostories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymManagmentDAL.Entities;
using GymManagmentDAL.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace GymManagmentDAL.Repostories.Classes
{
    public class SessionRepository : GenericRepostory<Session>, ISessionRepository
    {
        private readonly GymDBContext _context;
        public SessionRepository(GymDBContext context) : base(context)
        {
            _context = context;
        }
        public IEnumerable<Session> GetAllSessionWithTrainerAndCategory()
        {
            return _context.Sessions
                .Include(s => s.SessionTrainer)
                .Include(s => s.SessionCategory)
                .ToList();
        }

        public int GetCountOfBookedSlot(int sessionId)
        {
            return _context.MemberSessions
                .Where(x => x.SessionId == sessionId)
                .Count();
        }

        public Session? GetSessionWithTrainerAndCategory(int sessionId)
        {
            return _context.Sessions
                .Include (s => s.SessionTrainer)
                .Include(s => s.SessionCategory)
                .FirstOrDefault(x => x.Id == sessionId);
        }
    }
}
