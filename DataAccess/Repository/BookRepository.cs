using DataAccess.Context;
using DataAccess.Repository.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class BookRepository : BaseRepository<Book>, IBookRepository
    {
        public BookRepository(LibraryContext context) : base(context) { }
        public async Task<IReadOnlyCollection<Book>> FindAllBooksAllIncludedAsync()
        {
            return await Entities.ToListAsync().ConfigureAwait(false);
        }

        public async Task<IReadOnlyCollection<Book>> FindBookByConditionAllIncludedAsync(Expression<Func<Book, bool>> bookPredicate)
        {
            return await this.Entities.Where(bookPredicate).ToListAsync().ConfigureAwait(false);
        }

        public async Task<Book> GetBookAllIncludedAsync(Expression<Func<Book, bool>> bookPredicate)
        {
            return await libraryContext.Books.Where(bookPredicate).FirstOrDefaultAsync();
        }

        public async Task<Book> GetByIdAsync(int id)
        {
            return await libraryContext.Books.Where(x => x.Id == id).FirstOrDefaultAsync();
        }
    }
}
