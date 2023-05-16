using Microsoft.EntityFrameworkCore;
using Orders.DLL.Data;
using Orders.DLL.Interfaces;
using Orders.Domain.Entities;

namespace Orders.DLL.Repositories
{
    public class OrderRepository : IRepository<Order>
    {
        private readonly AppDBcontext _dbContext;
        
        public OrderRepository(AppDBcontext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Order> Create(Order entity)
        {
            try
            {
                await _dbContext.Order.AddAsync(entity);
                await _dbContext.SaveChangesAsync();
                return entity;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Order> Delete(int id)
        {
            try
            {
                var order = await _dbContext.Order.FindAsync(id);
                _dbContext.Order.Remove(order);
                await _dbContext.SaveChangesAsync();
                return order;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Order>> Get()
        {
            try
            {
                var orders = await _dbContext.Order.ToListAsync();
                return orders;
            }
            catch(Exception ex) 
            { 
                throw ex; 
            }
        }

        public async Task<Order> Get(int id)
        {
            try
            {
                var order = await _dbContext.Order.FindAsync(id);
                return order;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Order> Update(Order entity)
        {
            try
            {
                var order = _dbContext.Order.Entry(entity);
                order.State = EntityState.Modified;
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
