using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UE.STOREDB.DOMAIN.Core.Entities;
using UE.STOREDB.DOMAIN.Infrastructure.Data;

namespace UE.STOREDB.DOMAIN.Infrastructure.Repositories
{
    public class CategoryRepository
    {
        private readonly StoreDbueContext _dbContext;

        public CategoryRepository(StoreDbueContext dbContext)
        {
            _dbContext = dbContext;
        }

        public string getName()
        {
            return "Luis";
        }

        ////Sincrono
        //public IEnumerable<Category> GetAll()
        //{
        //    return _dbContext
        //            .Category
        //            .Where(c => c.IsActive == true)
        //            .ToList();
        //}

        public async Task<IEnumerable<Category>> GetAll()
        {
            return await _dbContext
                    .Category
                    .Where(c => c.IsActive == true)
                    .ToListAsync();
        }

        public async Task<Category> GetById(int id)
        {
            return await _dbContext
                    .Category
                    .Where(c => c.IsActive == true && c.Id == id)
                    .FirstOrDefaultAsync();
        }

    }
}
