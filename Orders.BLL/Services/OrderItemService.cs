using Orders.BLL.Interfaces;
using Orders.DLL.Interfaces;
using Orders.DLL.Repositories;
using Orders.Domain.DTO;
using Orders.Domain.Entities;

namespace Orders.BLL.Services
{
    public class OrderItemService : IOrderItemService
    {
        private readonly IRepository<OrderItem> _repository;

        public OrderItemService(IRepository<OrderItem> repository)
        {
            _repository = repository;
        }

        public async Task<OrderItemDto> Create(OrderItemDto entity)
        {
            try
            {
                var orderItem = new OrderItem
                {
                    Id = entity.Id,
                    ItemId = entity.ItemId,
                    OrderId = entity.OrderId,
                };
                var result = await _repository.Create(orderItem);
                return new OrderItemDto
                {
                    Id = result.Id,
                    OrderId = result.OrderId,
                    ItemId = result.ItemId,
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<OrderItemDto> Delete(int id)
        {
            try
            {
                var result = await _repository.Delete(id);
                return new OrderItemDto
                {
                    Id = result.Id,
                    OrderId = result.OrderId,
                    ItemId = result.ItemId,
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<IEnumerable<OrderItemDto>> Get()
        {
            try
            {
                var results = await _repository.Get();
                return from result in results
                       select
                       new OrderItemDto
                       {
                           Id = result.Id,
                           OrderId = result.OrderId,
                           ItemId = result.ItemId,
                       };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<OrderItemDto> Get(int id)
        {
            try
            {
                var result = await _repository.Get(id);
                return new OrderItemDto
                {
                    Id = result.Id,
                    OrderId = result.OrderId,
                    ItemId = result.ItemId,
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<OrderItemDto> Update(OrderItemDto entity)
        {
            try
            {
                var orderItem = new OrderItem
                {
                    Id = entity.Id,
                    ItemId = entity.ItemId,
                    OrderId = entity.OrderId,
                };
                var result = await _repository.Update(orderItem);
                return new OrderItemDto
                {
                    Id = result.Id,
                    OrderId = result.OrderId,
                    ItemId = result.ItemId,
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
