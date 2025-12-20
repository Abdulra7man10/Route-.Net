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
    public class CategoryRepository : ICategoryRepository
    {
        private readonly GymDBContext _context = new GymDBContext();
        public IEnumerable<Category> GetAll() => _context.Categories.ToList();
        public Category? GetById(int id) => _context.Categories.Find(id);
        public int Add(Category entity) { _context.Categories.Add(entity); return _context.SaveChanges(); }
        public int Update(Category entity) { _context.Categories.Update(entity); return _context.SaveChanges(); }
        public int Delete(int id)
        {
            var item = _context.Categories.Find(id);
            if (item != null) { _context.Categories.Remove(item); return _context.SaveChanges(); }
            return 0;
        }
    }
}
