using Domain.Models;
using System.Threading.Tasks;

namespace DataAccess.Repository.Interfaces
{
    public interface ITagRepository
    {
        Task<Tag> GetByIdAsync(int id);
    }
}
