using System;
using System.Collections.Generic;
using MvcUserGroupTour.DataTransferObjects;
using MvcUserGroupTour.Objects;

namespace MvcUserGroupTour.Mapper
{
    class OrderMapper : IOrderMapper
    {
        public OrderDto From(Order order)
        {
            return new OrderDto
                       {
                           OrderID = order.OrderID,
                           CustomerID = order.CustomerID,
                           EmployeeID = order.EmployeeID,
                           OrderDate = order.OrderDate,
                           RequiredDate = order.RequiredDate,
                           ShippedDate = order.ShippedDate,
                           ShipVia = order.ShipVia,
                           Freight = order.Freight,
                           ShipName = order.ShipName,
                           ShipAddress = order.ShipAddress,
                           ShipCity = order.ShipCity,
                           ShipRegion = order.ShipCity,
                           ShipPostalCode = order.ShipPostalCode,
                           ShipCountry = order.ShipCountry
                       };
        }

        public IEnumerable<OrderDto> From(IEnumerable<Order> orders)
        {
            var orderDtos = new List<OrderDto>();
            foreach (var order in orders)
            {
                orderDtos.Add(From(order));
            }
            return orderDtos;
        }
    }
}