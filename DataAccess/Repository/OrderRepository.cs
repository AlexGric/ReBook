using DataAccess.Context;
using DataAccess.Repository.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(LibraryContext context) : base(context) { }

        public async Task<Order> GetByIdAsync(int id)
        {
            return await libraryContext.Orders.Where(x => x.Id == id).FirstOrDefaultAsync();
        }
    }
}
