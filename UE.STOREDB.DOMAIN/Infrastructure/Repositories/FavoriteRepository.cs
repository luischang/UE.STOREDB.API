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
    public class FavoriteRepository : IFavoriteRepository
    {
        private readonly StoreDbueContext _dbContext;
        public FavoriteRepository(StoreDbueContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Favorite>> GetAll(int userId)
        {
            return await _dbContext
                            .Favorite
                            .Where(p => p.UserId == userId)
                            .Include(x => x.User)
                            .Include(z => z.Product)
                            .ThenInclude(q => q.Category)
                            .ToListAsync();
        }

        public async Task<bool> Insert(Favorite favorite)
        {
            await _dbContext.Favorite.AddAsync(favorite);
            int countRows = await _dbContext.SaveChangesAsync();
            return countRows > 0;
        }

        public async Task<bool> Delete(int id)
        {
            var favorite = await _dbContext.Favorite.FindAsync(id);
            if (favorite == null)
                return false;

            int countRows = await _dbContext.SaveChangesAsync();
            return countRows > 0;
        }

    }
}
