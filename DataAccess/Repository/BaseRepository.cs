using DataAccess.Context;
using DataAccess.Infrastructure;
using DataAccess.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected BaseRepository(LibraryContext context)
        {
            libraryContext = context;
        }
        private DbSet<TEntity> _entities;
        protected LibraryContext libraryContext;
        protected DbSet<TEntity> Entities => this._entities ??= libraryContext.Set<TEntity>();
        public virtual async Task<IReadOnlyCollection<TEntity>> GetAllAsync()
        {
            return await this.Entities.ToListAsync().ConfigureAwait(false);
        }
        public virtual async Task<IReadOnlyCollection<TEntity>> FindByConditionAsync(Expression<Func<TEntity, bool>> predicat)
        {
            return await this.Entities.Where(predicat).ToListAsync().ConfigureAwait(false);
        }
        public async Task<OperationDetail> CreateAsync(TEntity entity)
        {
            try
            {
                await Entities.AddAsync(entity).ConfigureAwait(false);
                return new OperationDetail { Message = "Created" };
            }
            catch (Exception e)
            {
                Log.Error(e, "Create Fatal Error");
                return new OperationDetail { IsError = true, Message = "Create Fatal Error" };
            }
        }
    }


}

