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
    public class ProductRepository : IProductRepository
    {
        private readonly StoreDbueContext _dbContext;

        public ProductRepository(StoreDbueContext storeDbContext)
        {
            _dbContext = storeDbContext;
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _dbContext
                            .Product
                            .Where(x => x.IsActive == true)
                            .Include(z => z.Category)
                            .ToListAsync();
        }
    }
}
