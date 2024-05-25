using UE.STOREDB.DOMAIN.Core.Entities;

namespace UE.STOREDB.DOMAIN.Core.Interfaces
{
    public interface IOrderDetailRepository
    {
        Task<bool> Insert(IEnumerable<OrderDetail> orderDetails);
    }
}