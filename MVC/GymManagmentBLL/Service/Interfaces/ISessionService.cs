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
        //bool CreateSession(CreateSessionViewModel createSessionViewModel);
        //SessionViewModel? GetSessionDetails(int id);
        //SessionToUpdateViewModel? GetSessionToUpdate(int sessionId);
        //bool UpdateSession(int sessionId, SessionToUpdateViewModel sessionToUpdate);
        //bool RemoveSession(int sessionId);
    }
}
