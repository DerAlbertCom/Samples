using System;
using System.Collections.Generic;
using MvcUserGroupTour.DataTransferObjects;
using MvcUserGroupTour.Objects;

namespace MvcUserGroupTour.Mapper
{
    internal class CustomerMapper : ICustomerMapper
    {
        public IEnumerable<CustomerDto> From(IEnumerable<Customer> customers)
        {
            var customerDtos = new List<CustomerDto>();
            foreach (var customer in customers)
            {
                customerDtos.Add(From(customer));
            }
            return customerDtos;
        }

        public void To(CustomerDto dto, ref Customer customer)
        {
            customer.CompanyName = dto.CompanyName;
            customer.ContactName = dto.ContactName;
            customer.ContactTitle = dto.ContactTitle;
            customer.Address = dto.Address;
            customer.City = dto.City;
            customer.Region = dto.Region;
            customer.PostalCode = dto.PostalCode;
            customer.Country = dto.Country;
            customer.Phone = dto.Phone;
            customer.Fax = dto.Fax;
        }


        public CustomerDto From(Customer customer)
        {
            return new CustomerDto
                       {
                           CustomerID = customer.CustomerID,
                           CompanyName = customer.CompanyName,
                           ContactName = customer.ContactName,
                           ContactTitle = customer.ContactTitle,
                           Address = customer.Address,
                           City = customer.City,
                           Region = customer.Region,
                           PostalCode = customer.PostalCode,
                           Country = customer.Country,
                           Phone = customer.Phone,
                           Fax = customer.Fax
                       };
        }
    }
}