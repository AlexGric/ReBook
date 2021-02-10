using Domain.Models;
using System.Threading.Tasks;

namespace DataAccess.Repository.Interfaces
{
    public interface ITagRepository : IRepository<Tag>
    {
        Task<Tag> GetByIdAsync(int id);
    }
}
