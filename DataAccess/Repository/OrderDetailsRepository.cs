using DataAccess.Context;
using DataAccess.Repository.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class OrderDetailsRepository : BaseRepository<OrderDetail>, IOrderDetailsRepository
    {
        public OrderDetailsRepository(LibraryContext context) : base(context) { }

        public async Task<OrderDetail> GetByIdAsync(int id)
        {
            return await libraryContext.OrderDetails.Where(x => x.Id == id).FirstOrDefaultAsync();
        }
    }
}
