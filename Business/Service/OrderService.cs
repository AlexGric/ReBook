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
    class OrderService
    {
        private readonly IUnitOfWork unitOfWork;
        public OrderService(IUnitOfWork unitOfWork) => this.unitOfWork = unitOfWork;

        public async Task<OperationDetail> CreateAsync(Order entity)
        {
            var res = await unitOfWork.OrderRepository.CreateAsync(entity);
            await unitOfWork.SaveChangesAsync();
            return res;
        }

        public async Task<IReadOnlyCollection<Order>> FindByConditionAsync(Expression<Func<Order, bool>> predicat)
        {
            return await unitOfWork.OrderRepository.FindByConditionAsync(predicat);
        }


        public async Task<IReadOnlyCollection<Order>> GetAllAsync()
        {
            return await unitOfWork.OrderRepository.GetAllAsync();
        }
    }
}
