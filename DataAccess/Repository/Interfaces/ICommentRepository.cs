using Domain.Models;
using System.Threading.Tasks;

namespace DataAccess.Repository.Interfaces
{
    public interface ICommentRepository : IRepository<Comment>
    {
        Task<Comment> GetByIdAsync(int id);
    }
}
