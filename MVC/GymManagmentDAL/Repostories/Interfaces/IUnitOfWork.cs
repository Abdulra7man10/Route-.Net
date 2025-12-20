using GymManagmentDAL.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagmentDAL.Repostories.Interfaces
{
    public interface IUnitOfWork
    {
        public ISessionRepository sessionRepository { get; }
        int SaveChange();
        IGenericRepostory<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity, new();
    }
}
