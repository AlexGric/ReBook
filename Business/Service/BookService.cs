using DataAccess.Infrastructure;
using DataAccess.UnitOfWork;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service
{
    public class BookService
    {
        private IUnitOfWork unitOfWork;
        public BookService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<OperationDetail> CreateAsync(Book entity)
        {
            var res = await unitOfWork.BookRepository.CreateAsync(entity);
            await unitOfWork.SaveChangesAsync();
            return res;
        }

        public async Task<IReadOnlyCollection<Address>> FindByConditionAsync(Expression<Func<Address, bool>> predicat)
        {
            return await _unitOfWork.AddressRepository.FindByConditionAsync(predicat);
        }

        public async Task<IReadOnlyCollection<Address>> GetAllAsync()
        {
            return await _unitOfWork.AddressRepository.GetAllAsync();
        }
    }
}
