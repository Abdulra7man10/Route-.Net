using GymManagmentDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagmentDAL.Repostories.Interfaces
{
    public interface IHealthRecordRepository
    {
        IEnumerable<HealthRecord> GetAll();
        HealthRecord? GetById(int id);
        int Add(HealthRecord entity);
        int Update(HealthRecord entity);
        int Delete(int id);
    }
}
