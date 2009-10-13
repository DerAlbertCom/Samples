using System;
using System.Collections.Generic;
using System.Linq;
using MvcUserGroupTour.Objects;

namespace MvcUserGroupTour.Repositories
{
    public class CustomerRepository : RepositoryBase, ICustomerRepository
    {
        public void Save(Customer customer)
        {
            ExecuteInDataContext(ctx =>
                                     {
                                         ctx.Customers.InsertOnSubmit(customer);
                                         ctx.SubmitChanges();
                                     }
                );
        }

        public Customer GetById(string customerId)
        {
            Customer customer = null;
            ExecuteInDataContext(ctx => customer = ctx.Customers.Where(c => c.CustomerID == customerId).Single());
            return customer;
        }

        public void Update(Customer customer)
        {
            ExecuteInDataContext(ctx => ctx.SubmitChanges());
        }

        public IEnumerable<Order> GetOrdersForCustomer(string customerId)
        {
            List<Order> orders = null;
            ExecuteInDataContext(
                ctx => orders = (from o in ctx.Orders where o.CustomerID == customerId select o).ToList());
            return orders;
        }

        public IEnumerable<Customer> SearchBy(string searchText)
        {
            IEnumerable<Customer> customers = null;
            ExecuteInDataContext(ctx =>
                                 customers = ctx.Customers
                                                 .Where(c => c.CompanyName.Contains(searchText)
                                                             || c.ContactName.Contains(searchText)
                                                             || c.CustomerID.Contains(searchText))
                                                 .ToList());
            return customers;
        }

        public IEnumerable<Customer> GetCustomers()
        {
            List<Customer> customers = null;
            ExecuteInDataContext(ctx => customers = ctx.Customers.ToList());
            return customers;
        }

        public IEnumerable<Customer> GetCustomers(Func<IQueryable<Customer>, IQueryable<Customer>> selection)
        {
            List<Customer> customers = null;
            ExecuteInDataContext(ctx => customers = selection(ctx.Customers).ToList());
            return customers;
        }
    }
}