using Domain.Models;
using System.Threading.Tasks;

namespace DataAccess.Repository.Interfaces
{
    public interface IOrderDetailsRepository
    {
        Task<OrderDetail> GetByIdAsync(int id);
    }
}
