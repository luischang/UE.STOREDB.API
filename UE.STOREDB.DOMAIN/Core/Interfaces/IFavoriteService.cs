using UE.STOREDB.DOMAIN.Core.DTO;

namespace UE.STOREDB.DOMAIN.Core.Interfaces
{
    public interface IFavoriteService
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<FavoriteListDTO>> GetAll(int userId);
        Task<bool> Insert(FavoriteInsertDTO favoriteDTO);
    }
}