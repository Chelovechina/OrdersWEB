using Microsoft.EntityFrameworkCore;
using Orders.DLL.Data;
using Orders.DLL.Interfaces;
using Orders.Domain.Entities;

namespace Orders.DLL.Repositories
{
    public class ItemRepository : IRepository<Item>
    {
        private readonly AppDBcontext _dbContext;

        public ItemRepository(AppDBcontext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Item> Create(Item entity)
        {
            try
            {
                await _dbContext.Item.AddAsync(entity);
                await _dbContext.SaveChangesAsync();
                return entity;
            }
            catch(Exception ex) {
                throw ex;
            }
        }

        public async Task<IEnumerable<Item>> Get()
        {
            try
            {
                var items = await _dbContext.Item.ToListAsync();
                return items;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Item> Get(int id)
        {
            try
            {
                var item = await _dbContext.Item.FindAsync(id);
                return item;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Item> Update(Item entity)
        {
            try
            {
                var item = _dbContext.Item.Entry(entity);
                item.State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
                return entity;
            }
            catch(Exception ex) 
            {
                throw ex;
            }
        }

        public async Task<Item> Delete(int id)
        {
            try
            {
                var item = await _dbContext.Item.FindAsync(id);
                _dbContext.Item.Remove(item);
                await _dbContext.SaveChangesAsync();
                return item;
            } 
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
