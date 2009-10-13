using System.Collections.Generic;
using MvcUserGroupTour.DataTransferObjects;

namespace MvcUserGroupTour.Services
{
    public interface ICustomerService
    {
        IEnumerable<CustomerDto> GetFirst5Customers();
        void SaveCustomer(CustomerDto customer);
        void UpdateCustomer(CustomerDto customer);
        CustomerDto GetCustomer(string customerId);
        IEnumerable<OrderDto> GetOrdersForCustomer(string customerId);
        IEnumerable<CustomerDto> GetCustomersForSearch(string searchText);
    }
}