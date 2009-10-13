using System.Collections.Generic;
using MvcUserGroupTour.DataTransferObjects;
using MvcUserGroupTour.Objects;

namespace MvcUserGroupTour.Mapper
{
    public interface ICustomerMapper
    {
        IEnumerable<CustomerDto> From(IEnumerable<Customer> customers);
        void To(CustomerDto dto, ref Customer customer);
        CustomerDto From(Customer customer);
    }
}