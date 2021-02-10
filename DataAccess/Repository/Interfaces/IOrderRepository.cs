using Domain.Models;
using System.Threading.Tasks;

namespace DataAccess.Repository.Interfaces
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<Order> GetByIdAsync(int id);
    }
}
