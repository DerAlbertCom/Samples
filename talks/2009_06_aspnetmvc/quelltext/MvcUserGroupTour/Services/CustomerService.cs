using System;
using System.Collections.Generic;
using System.Linq;
using MvcUserGroupTour.DataTransferObjects;
using MvcUserGroupTour.Mapper;
using MvcUserGroupTour.Objects;
using MvcUserGroupTour.Repositories;

namespace MvcUserGroupTour.Services
{
    internal class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository repository;
        private readonly ICustomerMapper mapper;
        private IOrderMapper orderMapper;
        public CustomerService(ICustomerRepository repository, ICustomerMapper mapper, IOrderMapper orderMapper)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.orderMapper = orderMapper;
        }

        public IEnumerable<CustomerDto> GetFirst5Customers()
        {
            var customers = repository.GetCustomers(c => c.Take(5));
            return mapper.From(customers);
        }

        public void SaveCustomer(CustomerDto customerDto)
        {
            repository.ExecuteInDataContext(() =>
                                                {
                                                    var customer = new Customer {CustomerID = customerDto.CustomerID};
                                                    mapper.To(customerDto, ref customer);
                                                    repository.Save(customer);
                                                }
                );
        }

        public void UpdateCustomer(CustomerDto customerDto)
        {
            repository.ExecuteInDataContext(() =>
                                                {
                                                    var customer = repository.GetById(customerDto.CustomerID);
                                                    mapper.To(customerDto, ref customer);
                                                    repository.Update(customer);
                                                }
                );
        }

        public CustomerDto GetCustomer(string id)
        {
            return mapper.From(repository.GetById(id));
        }

        public IEnumerable<OrderDto> GetOrdersForCustomer(string customerId)
        {
            return orderMapper.From(repository.GetOrdersForCustomer(customerId));
        }

        public IEnumerable<CustomerDto> GetCustomersForSearch(string searchText)
        {
            return mapper.From(repository.SearchBy(searchText));
        }
    }
}