using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.Interfases
{
    public interface IBookRepository
    {
        Task<IReadOnlyCollection<Book>> FindAllBooksAllIncludedAsync();
        Task<IReadOnlyCollection<Book>> FindBookByConditionAllIncludedAsync(Expression<Func<Book, bool>> bookPredicate);
        Task<Book> GetBookAllIncludedAsync(Expression<Func<Book, bool>> bookPredicate);
        Task<Book> GetByIdAsync(int id);
    }
}
