using DataAccess.Context;
using DataAccess.Infrastructure;
using DataAccess.Repository.Interfases;
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
        private DbSet<TEntity> entities { get; set; } 
        protected LibraryContext libraryContext { set; get; } // database context
        protected DbSet<TEntity> Entities => this.entities ??= libraryContext.Set<TEntity>(); //all models from context. Return entities if it's not null or return Set<Tentity>

        protected  BaseRepository(LibraryContext context)
        {
            this.libraryContext = context;
        }

        public virtual async Task<OperationDetail> CreateAsync(TEntity entity) // create new database context 
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
        public virtual async Task<IReadOnlyCollection<TEntity>> GetAllAsync() // get all entities from db table
        {
            return await this.Entities.ToListAsync().ConfigureAwait(false);
        }

        public virtual async Task<IReadOnlyCollection<TEntity>> FindByConditionAsync(Expression<Func<TEntity, bool>> predicat) // find element from databese table
        {
            return await this.Entities.Where(predicat).ToListAsync().ConfigureAwait(false);
        }

        
    }
}
