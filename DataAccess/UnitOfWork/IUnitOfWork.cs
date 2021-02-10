using DataAccess.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.UnitOfWork
{
    public interface IUnitOfWork
    {
        ICommentRepository CommentRepository { get; }
        IUserRepository UserRepository { get; }       
        IGenreRepository GenreRepository { get; }
        IOrderDetailsRepository OrderDetailsRepository { get; }
        IOrderRepository OrderRepository { get; }
        ITagRepository TagRepository { get; }
        IBookRepository BookRepository { get; }



        Task SaveChangesAsync();
    }
}
