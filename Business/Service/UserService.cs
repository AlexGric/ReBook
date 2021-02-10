using DataAccess.Infrastructure;
using DataAccess.UnitOfWork;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service
{
    class UserService
    {
        private readonly IUnitOfWork unitOfWork;
        public UserService(IUnitOfWork unitOfWork) => this.unitOfWork = unitOfWork;

        public async Task<OperationDetail> CreateAsync(User entity)
        {
            var res = await unitOfWork.UserRepository.CreateAsync(entity);
            await unitOfWork.SaveChangesAsync();
            return res;
        }

        public async Task<IReadOnlyCollection<User>> FindByConditionAsync(Expression<Func<User, bool>> predicat)
        {
            return await unitOfWork.UserRepository.FindByConditionAsync(predicat);
        }


        public async Task<IReadOnlyCollection<User>> GetAllAsync()
        {
            return await unitOfWork.UserRepository.GetAllAsync();
        }
    }
}
