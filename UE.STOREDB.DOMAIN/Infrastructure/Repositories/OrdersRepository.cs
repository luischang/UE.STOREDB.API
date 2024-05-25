using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UE.STOREDB.DOMAIN.Core.Entities;
using UE.STOREDB.DOMAIN.Core.Interfaces;
using UE.STOREDB.DOMAIN.Infrastructure.Data;

namespace UE.STOREDB.DOMAIN.Infrastructure.Repositories
{
    public class OrdersRepository : IOrdersRepository
    {
        private readonly StoreDbueContext _dbContext;
        public OrdersRepository(StoreDbueContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Insert(Orders orders)
        {
            await _dbContext.Orders.AddAsync(orders);
            await _dbContext.SaveChangesAsync();
            return orders.Id;
        }
        public async Task<IEnumerable<Orders>> GetAllByUserId(int userId)
        {
            return await _dbContext.Orders.Where(x => x.UserId == userId).ToListAsync();
        }
        public async Task<Orders> GetById(int id)
        {
            return await _dbContext
                        .Orders
                        .Where(x => x.Id == id && x.Status.Equals("A"))
                        .Include(u => u.User)
                        .FirstOrDefaultAsync();
        }

        // Delete order by id
        public async Task<bool> Delete(int id)
        {
            var findOrders = await _dbContext.Orders.FindAsync(id);
            if (findOrders == null) return false;

            findOrders.Status = "D";

            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
