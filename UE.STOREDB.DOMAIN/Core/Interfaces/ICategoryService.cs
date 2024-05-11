using UE.STOREDB.DOMAIN.Core.DTO;

namespace UE.STOREDB.DOMAIN.Core.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryListDTO>> GetAll();
        Task<IEnumerable<CategoryProductstDTO>> GetWithProducts();
        Task<CategoryListDTO> GetById(int id);
        Task<CategoryProductstDTO> GetByIdWithProducts(int id);
        Task<bool> Create(CategoryCreateDTO categoryCreate);

    }
}