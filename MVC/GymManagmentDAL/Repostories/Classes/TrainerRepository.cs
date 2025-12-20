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
    public class TrainerRepository : GenericRepostory<Trainer>
    {
        private readonly GymDBContext _context;
        public TrainerRepository(GymDBContext context) : base(context)
        {
            _context = context;
        }

        //public IEnumerable<Trainer> GetAll() => _context.Trainers.ToList();
        //public Trainer? GetById(int id) => _context.Trainers.Find(id);
        //public int Add(Trainer entity) { _context.Trainers.Add(entity); return _context.SaveChanges(); }
        //public int Update(Trainer entity) { _context.Trainers.Update(entity); return _context.SaveChanges(); }
        //public int Delete(int id)
        //{
        //    var item = _context.Trainers.Find(id);
        //    if (item != null) { _context.Trainers.Remove(item); return _context.SaveChanges(); }
        //    return 0;
        //}
    }
}
