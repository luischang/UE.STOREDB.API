using UE.STOREDB.DOMAIN.Core.DTO;

namespace UE.STOREDB.DOMAIN.Core.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryListDTO>> GetAll();
        Task<IEnumerable<CategoryProductstDTO>> GetWithProducts();
    }
}