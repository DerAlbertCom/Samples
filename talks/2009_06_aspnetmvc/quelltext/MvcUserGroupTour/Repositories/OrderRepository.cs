using System;
using System.Linq;
using MvcUserGroupTour.Objects;

namespace MvcUserGroupTour.Repositories
{
    class OrderRepository : RepositoryBase, IOrderRepository
    {
        public Order GetById(int orderId)
        {
            Order order = null;
            ExecuteInDataContext(ctx=>order=ctx.Orders.Where(o=>o.OrderID==orderId).Single());
            return order;
        }
    }
}