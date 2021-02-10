using Domain.Models;
using System.Threading.Tasks;

namespace DataAccess.Repository.Interfaces
{
    public interface IGenreRepository : IRepository<Genre>
    {
        Task<Genre> GetByIdAsync(int id);
    }
}
