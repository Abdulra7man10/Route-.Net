using GymManagmentDAL.Repostories.Interfaces;
using GymManagmentDAL.Entities;
using GymManagmentDAL.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GymManagmentDAL.Repostories.Classes
{
    public class GenericRepostory<TEntity> : IGenericRepostory<TEntity> where TEntity : BaseEntity, new()
    {
        private readonly GymDBContext _context;
        public GenericRepostory(GymDBContext context)
        {
            _context = context;
        }
        public void Add(TEntity entity) => _context.Set<TEntity>().Add(entity);
        public void Update(TEntity entity) => _context.Set<TEntity>().Update(entity);

        public void Delete(TEntity entity) => _context.Set<TEntity>().Remove(entity);

        public IEnumerable<TEntity> GetAll(Func<TEntity, bool>? condition = null)
        {
            if (condition is null)
                return _context.Set<TEntity>().AsNoTracking().ToList();
            return _context.Set<TEntity>().AsNoTracking().Where(condition).ToList();
        }

        public TEntity? GetById(int id) => _context.Set<TEntity>().Find(id);

    }
}
