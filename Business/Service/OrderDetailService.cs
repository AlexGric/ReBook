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
    class OrderDetailService
    {
        private readonly IUnitOfWork unitOfWork;
        public OrderDetailService(IUnitOfWork unitOfWork) => this.unitOfWork = unitOfWork;

        public async Task<OperationDetail> CreateAsync(OrderDetail entity)
        {
            var res = await unitOfWork.OrderDetailsRepository.CreateAsync(entity);
            await unitOfWork.SaveChangesAsync();
            return res;
        }

        public async Task<IReadOnlyCollection<OrderDetail>> FindByConditionAsync(Expression<Func<OrderDetail, bool>> predicat)
        {
            return await unitOfWork.OrderDetailsRepository.FindByConditionAsync(predicat);
        }


        public async Task<IReadOnlyCollection<OrderDetail>> GetAllAsync()
        {
            return await unitOfWork.OrderDetailsRepository.GetAllAsync();
        }
    }
}
