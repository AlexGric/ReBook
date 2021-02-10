using DataAccess.Infrastructure;
using DataAccess.UnitOfWork;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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

        public async Task<IReadOnlyCollection<Book>> FindByConditionAsync(Expression<Func<Book, bool>> predicat)
        {
            return await unitOfWork.BookRepository.FindByConditionAsync(predicat);
        }

        public async Task<IReadOnlyCollection<Book>> GetAllAsync()
        {
            return await unitOfWork.BookRepository.GetAllAsync();
        }
    }
}
