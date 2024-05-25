using UE.STOREDB.DOMAIN.Core.Entities;

namespace UE.STOREDB.DOMAIN.Core.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> Insert(User user);
        Task<User> SignIn(string email, string pwd);
    }
}