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
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private readonly StoreDbueContext _dbContext;
        public OrderDetailRepository(StoreDbueContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Insert(IEnumerable<OrderDetail> orderDetails)
        {
            await _dbContext.OrderDetail.AddRangeAsync(orderDetails);
            decimal totalAmount = (decimal)orderDetails.Sum(od => od.Quantity * od.Price);
            var order = await _dbContext.Orders.FindAsync(orderDetails.First().OrdersId);
            order.TotalAmount = totalAmount;
            _dbContext.Orders.Update(order);
            int countRows = await _dbContext.SaveChangesAsync();
            return countRows > 0;
        }
    }
}
