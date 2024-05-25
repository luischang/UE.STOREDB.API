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
    public class UserRepository : IUserRepository
    {
        private readonly StoreDbueContext _dbContext;

        public UserRepository(StoreDbueContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Insert(User user)
        {
            await _dbContext.User.AddAsync(user);
            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<User> SignIn(string email, string pwd)
        {
            return await _dbContext
                .User
                .Where(x => x.Email == email && x.Password == pwd)
                .FirstOrDefaultAsync();
        }
    }
}
