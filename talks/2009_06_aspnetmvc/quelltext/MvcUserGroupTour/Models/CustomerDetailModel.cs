using System.Collections.Generic;
using MvcUserGroupTour.DataTransferObjects;

namespace MvcUserGroupTour.Models
{
    public class CustomerDetailModel
    {
        public CustomerDto Customer;
        public IEnumerable<OrderDto> Orders;
    }
}