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
    //public class PlanRepository : IPlanRepostory
    //{
    //    private readonly GymDBContext _context;
    //    public PlanRepository(GymDBContext context)
    //    {
    //        _context = context;
    //    }

    //    public IEnumerable<Plan> GetAll() => _context.Plans.ToList();
    //    public Plan? GetById(int id) => _context.Plans.Find(id);
    //    //public int Add(Plan entity) { _context.Plans.Add(entity); return _context.SaveChanges(); }
    //    public int Update(Plan entity) { _context.Plans.Update(entity); return _context.SaveChanges(); }
    //    /*public int Delete(int id)
    //    {
    //        var item = _context.Plans.Find(id);
    //        if (item != null) { _context.Plans.Remove(item); return _context.SaveChanges(); }
    //        return 0;
    //    }*/
    //}
}
