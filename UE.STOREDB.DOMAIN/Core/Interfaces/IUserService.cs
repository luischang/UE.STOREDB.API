using UE.STOREDB.DOMAIN.Core.DTO;
using UE.STOREDB.DOMAIN.Core.Entities;

namespace UE.STOREDB.DOMAIN.Core.Interfaces
{
    public interface IUserService
    {
        Task<bool> Insert(User user);
        Task<UserResponseAuthDTO> SignIn(string email, string pwd);
    }
}