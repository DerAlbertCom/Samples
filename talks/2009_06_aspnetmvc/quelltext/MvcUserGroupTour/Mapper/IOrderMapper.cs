using System.Collections.Generic;
using MvcUserGroupTour.DataTransferObjects;
using MvcUserGroupTour.Objects;

namespace MvcUserGroupTour.Mapper
{
    public interface IOrderMapper
    {
        OrderDto From(Order order);
        IEnumerable<OrderDto> From(IEnumerable<Order> enumerable);
    }
}