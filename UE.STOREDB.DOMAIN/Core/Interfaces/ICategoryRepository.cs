using UE.STOREDB.DOMAIN.Core.Entities;

namespace UE.STOREDB.DOMAIN.Core.Interfaces
{
    public interface ICategoryRepository
    {
        Task<bool> Delete(int id);
        Task<bool> DeleteLogic(int id);
        Task<IEnumerable<Category>> GetAll();
        Task<Category> GetById(int id);
        Task<bool> Insert(Category category);
        Task<bool> Update(Category category);
    }
}