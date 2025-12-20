using GymManagmentDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagmentDAL.Repostories.Interfaces
{
    public interface IGenericRepostory<TEntity> where TEntity : BaseEntity, new() // to be sure it's not an abstract class
    {
        IEnumerable<TEntity> GetAll(Func<TEntity,bool>? condition=null);
        TEntity? GetById(int id);
        int Add(TEntity entity);
        int Update(TEntity entity);
        int Delete(TEntity entity);
    }
}
