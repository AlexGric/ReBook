using DataAccess.Context;
using DataAccess.Repository.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {       
        public UserRepository(LibraryContext context) : base(context) { }
        public override async Task<IReadOnlyCollection<User>> GetAllAsync()
        {
            return await this.Entities.ToListAsync().ConfigureAwait(false);
        }
        public override async Task<IReadOnlyCollection<User>> FindByConditionAsync(Expression<Func<User, bool>> predicat)
        {
            return await this.Entities.Where(predicat).ToListAsync().ConfigureAwait(false);
        }
        public async Task<IReadOnlyCollection<User>> FindAllUsersAllIncludedAsync()
        {
            return await this.Entities.Include(x => x.Comments).ToListAsync().ConfigureAwait(false);
        }

        public async Task<IReadOnlyCollection<User>> FindUserByConditionAllIncludedAsync(Expression<Func<User, bool>> userPredicate)
        {
            return await this.Entities.Where(userPredicate).Include(x => x.Comments).ToListAsync().ConfigureAwait(false);
        }

        public async Task<User> GetUserAllIncludedAsync(Expression<Func<User, bool>> userPredicate)
        {
            return await this.Entities.Where(userPredicate).Include(x => x.Comments).FirstOrDefaultAsync().ConfigureAwait(false);
        }
    }
}
