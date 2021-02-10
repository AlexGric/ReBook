using DataAccess.Context;
using DataAccess.Repository.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class CommentRepository : BaseRepository<Comment>, ICommentRepository
    {
        public CommentRepository(LibraryContext context) : base(context) { }
        public async Task<Comment> GetByIdAsync(int id)
        {
            return await libraryContext.Comments.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

    }
}
