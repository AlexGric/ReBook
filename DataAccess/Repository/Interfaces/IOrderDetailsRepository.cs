using Domain.Models;
using System.Threading.Tasks;

namespace DataAccess.Repository.Interfaces
{
    public interface IOrderDetailsRepository : IRepository<OrderDetail>
    {
        Task<OrderDetail> GetByIdAsync(int id);
    }
}
