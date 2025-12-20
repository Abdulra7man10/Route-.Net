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
    public class HealthRecordRepository : IHealthRecordRepository
    {
        private readonly GymDBContext _context = new GymDBContext();
        public IEnumerable<HealthRecord> GetAll() => _context.HealthRecords.ToList();
        public HealthRecord? GetById(int id) => _context.HealthRecords.Find(id);
        public int Add(HealthRecord entity) { _context.HealthRecords.Add(entity); return _context.SaveChanges(); }
        public int Update(HealthRecord entity) { _context.HealthRecords.Update(entity); return _context.SaveChanges(); }
        public int Delete(int id)
        {
            var item = _context.HealthRecords.Find(id);
            if (item != null) { _context.HealthRecords.Remove(item); return _context.SaveChanges(); }
            return 0;
        }
    }
}
