using GymManagmentDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagmentDAL.Repostories.Interfaces
{
    public interface IMembershipRepository
    {
        IEnumerable<Membership> GetAll();
        Membership? GetById(int id);
        int Add(Membership entity);
        int Update(Membership entity);
        int Delete(int id);
    }
}
