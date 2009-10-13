using System;
using MvcUserGroupTour.DataTransferObjects;
using MvcUserGroupTour.Mapper;
using MvcUserGroupTour.Repositories;

namespace MvcUserGroupTour.Services
{
    class OrderService : IOrderService
    {
        private readonly IOrderRepository repository;
        private readonly IOrderMapper mapper;

        public OrderService(IOrderRepository repository, IOrderMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public OrderDto GetOrderById(int orderId)
        {
            return mapper.From(repository.GetById(orderId));
        }
    }
}