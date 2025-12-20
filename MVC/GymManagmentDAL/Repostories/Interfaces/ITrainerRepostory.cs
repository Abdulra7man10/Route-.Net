using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymManagmentDAL.Entities;

namespace GymManagmentDAL.Repostories.Interfaces
{
    public interface ITrainerRepostory
    {
        // GetAll
        IEnumerable<Trainer> GetAll();

        // GetById
        Trainer? GetById(int id);

        // Add
        int Add(Trainer member);
        // Update
        int Update(Trainer member);
        // Delete
        int Delete(int id);
    }
}
