using MvcUserGroupTour.Objects;

namespace MvcUserGroupTour.Repositories
{
    public interface IOrderRepository : IRepositoryBase
    {
        Order GetById(int orderId);
    }
}