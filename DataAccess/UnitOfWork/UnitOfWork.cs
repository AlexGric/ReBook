using DataAccess.Context;
using DataAccess.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private LibraryContext libraryContext { get; }
        public ICommentRepository CommentRepository { get; }
        public IUserRepository UserRepository { get; }
        public IGenreRepository GenreRepository { get; }
        public IOrderDetailsRepository OrderDetailsRepository { get; }
        public IOrderRepository OrderRepository { get; }
        public ITagRepository TagRepository { get; }
        public IBookRepository BookRepository { get; }

        public UnitOfWork(LibraryContext libraryContext, IUserRepository userRepository, ICommentRepository commentRepository, 
            IOrderDetailsRepository orderDetailsRepository, IGenreRepository genreRepository, IOrderRepository orderRepository,
            ITagRepository tagRepository, IBookRepository bookRepository)
        {
            this.libraryContext = libraryContext;
            UserRepository = userRepository;
            CommentRepository = commentRepository;
            GenreRepository = genreRepository;
            OrderDetailsRepository = orderDetailsRepository;
            OrderRepository = orderRepository;
            TagRepository = tagRepository;
            BookRepository = bookRepository;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public async Task SaveChangesAsync()
        {
            try
            {
                await libraryContext.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                var sqlException = e.GetBaseException() as SqlException;
                //2601 is error number of unique index violation
                if (sqlException != null && sqlException.Number == 2601)
                {
                    //Unique index was violated. Show corresponding error message to user.
                }
            }
        }
    }
}
