using System.Web.Mvc;
using MvcUserGroupTour.DataTransferObjects;

namespace MvcUserGroupTour.Services
{
    public interface IOrderService
    {
        OrderDto GetOrderById(int orderId);
    }
}