using Microsoft.EntityFrameworkCore;
using Orders.DLL.Data;
using Orders.DLL.Interfaces;
using Orders.Domain.Entities;

namespace Orders.DLL.Repositories
{
    public class ProviderRepository : IRepository<Provider>
    {
        private readonly AppDBcontext _dbContext;

        public ProviderRepository(AppDBcontext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Provider> Create(Provider entity)
        {
            try 
            {
                await _dbContext.Provider.AddAsync(entity);
                await _dbContext.SaveChangesAsync();
                return entity;
            } 
            catch(Exception ex) 
            {
                throw ex;
            }
        }

        public async Task<Provider> Delete(int id)
        {
            try
            {
                var provider = await _dbContext.Provider.FindAsync(id);
                _dbContext.Provider.Remove(provider);
                await _dbContext.SaveChangesAsync();
                return provider;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Provider>> Get()
        {
            try
            {
                var providers = await _dbContext.Provider.ToListAsync();
                return providers;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Provider> Get(int id)
        {
            try
            {
                var provider = await _dbContext.Provider.FindAsync(id);
                return provider;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Provider> Update(Provider entity)
        {
            try
            {
                var provider = _dbContext.Provider.Entry(entity);
                provider.State = EntityState.Modified;
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
