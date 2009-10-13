using System;
using System.Collections.Generic;
using System.Linq;
using MvcUserGroupTour.Objects;

namespace MvcUserGroupTour.Repositories
{
    public interface ICustomerRepository : IRepositoryBase
    {
        IEnumerable<Customer> GetCustomers(Func<IQueryable<Customer>, IQueryable<Customer>> selection);
        void Save(Customer customer);
        Customer GetById(string customerId);
        void Update(Customer customer);
        IEnumerable<Order> GetOrdersForCustomer(string customerId);
        IEnumerable<Customer> SearchBy(string searchText);
    }
}