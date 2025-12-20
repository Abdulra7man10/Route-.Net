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
    public class HealthRecordRepository : GenericRepostory<HealthRecord>
    {
        private readonly GymDBContext _context;
        public HealthRecordRepository(GymDBContext context) : base(context)
        {
            _context = context;
        }
    }
}
