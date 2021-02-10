using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Expressions;
using DataAccess.Infrastructure;

namespace DataAccess.Repository.Interfaces
{
    public interface IRepository<TEntity>
   {
        Task<IReadOnlyCollection<TEntity>> GetAllAsync(); 
        Task<IReadOnlyCollection<TEntity>> FindByConditionAsync(Expression<Func<TEntity, bool>> predicat);
        Task<OperationDetail> CreateAsync(TEntity entity);

    }
}
