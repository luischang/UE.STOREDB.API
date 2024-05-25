using UE.STOREDB.DOMAIN.Core.DTO;

namespace UE.STOREDB.DOMAIN.Core.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductCategoryDTO>> GetAll();
    }
}