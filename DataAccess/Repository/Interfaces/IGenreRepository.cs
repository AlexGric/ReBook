using Domain.Models;
using System.Threading.Tasks;

namespace DataAccess.Repository.Interfaces
{
    public interface IGenreRepository
    {
        Task<Genre> GetByIdAsync(int id);
    }
}
