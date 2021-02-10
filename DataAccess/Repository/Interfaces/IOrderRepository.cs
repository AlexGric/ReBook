using Domain.Models;
using System.Threading.Tasks;

namespace DataAccess.Repository.Interfaces
{
    public interface IOrderRepository
    {
        Task<Order> GetByIdAsync(int id);
    }
}
