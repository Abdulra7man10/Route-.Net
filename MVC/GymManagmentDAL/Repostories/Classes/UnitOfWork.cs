using GymManagmentDAL.Data.Context;
using GymManagmentDAL.Entities;
using GymManagmentDAL.Repostories.Interfaces;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagmentDAL.Repostories.Classes
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Dictionary<Type, object> _repositories = new();
        private readonly GymDBContext _context;
        public UnitOfWork(GymDBContext context, ISessionRepository sessionRepository)
        {
            _context = context;
            this.sessionRepository = sessionRepository;
        }

        public ISessionRepository sessionRepository { get; }

        public IGenericRepostory<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity, new()
        {
            var EntityType = typeof(TEntity);
            if(_repositories.TryGetValue(EntityType, out var repo)) // in case you create it before
            {
                return (IGenericRepostory<TEntity>)repo; // when give you type give me the repo
            }

            var newRepo = new GenericRepostory<TEntity>(_context);
            _repositories[EntityType] = newRepo;
            return newRepo;
        }

        public int SaveChange()
        {
            return _context.SaveChanges();
        }
    }
}
