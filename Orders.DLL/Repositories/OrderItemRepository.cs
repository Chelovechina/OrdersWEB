using Microsoft.EntityFrameworkCore;
using Orders.DLL.Data;
using Orders.DLL.Interfaces;
using Orders.Domain.Entities;

namespace Orders.DLL.Repositories
{
    public class OrderItemRepository : IRepository<OrderItem>
    {
        private readonly AppDBcontext _dbContext;

        public OrderItemRepository(AppDBcontext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OrderItem> Create(OrderItem entity)
        {
            try
            {
                await _dbContext.OrderItem.AddAsync(entity);
                await _dbContext.SaveChangesAsync();
                return entity;
            }
            catch(Exception ex) 
            {
                throw ex;
            }
        }

        public async Task<OrderItem> Delete(int id)
        {
            try
            {
                var orderItem = await _dbContext.OrderItem.FindAsync(id);
                _dbContext.OrderItem.Remove(orderItem);
                await _dbContext.SaveChangesAsync();
                return orderItem;
            }
            catch(Exception ex) 
            { 
                throw ex; 
            }
        }

        public async Task<IEnumerable<OrderItem>> Get()
        {
            try
            {
                var orderItems = await _dbContext.OrderItem.ToListAsync();
                return orderItems;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<OrderItem> Get(int id)
        {
            try
            {
                var orderItem = await _dbContext.OrderItem.FindAsync(id);
                return orderItem;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<OrderItem> Update(OrderItem entity)
        {
            try
            {
                var orderItem = _dbContext.OrderItem.Entry(entity);
                orderItem.State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
                return entity;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
