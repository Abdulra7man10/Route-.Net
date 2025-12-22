using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymManagmentBLL.ViewModels.SessionViewModel;

namespace GymManagmentBLL.Service.Interfaces
{
    public interface ISessionService
    {
        IEnumerable<SessionViewModel> GetAllSessions();
        SessionViewModel? GetSessionById(int id);
        bool CreateSession(CreateSessionViewModel createSessionViewModel);
        UpdateSessionViewModel? GetSessionToUpdate(int sessionId);
        bool UpdateSession(int sessionId, UpdateSessionViewModel updateSession);
        bool RemoveSession(int sessionId);
    }
}
