using LaptopStores.Domain.Entities;
using LaptopStores.Domain.Interfaces;
using LaptopStores.Infrastructure.Persistences;
using Microsoft.EntityFrameworkCore;


namespace LaptopStores.Infrastructure.Repositories
{
    internal class LaptopStoreRepository : ILaptopStoreRepository
    {
        private readonly LaptopStoresDbContext _dbContext;
        public LaptopStoreRepository(LaptopStoresDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddLaptopStoreAsync(LaptopStore store)
        {
            await _dbContext.LaptopStores.AddAsync(store);
        }
        public async Task<LaptopStore?> GetLaptopStoreByIdAsync(Guid id)
        {
            return await _dbContext.LaptopStores.FindAsync(id);
        }
        public async Task<IEnumerable<LaptopStore>> GetAllLaptopStoresAsync()
        {
            return await _dbContext.LaptopStores.ToListAsync();
        }
        public async Task UpdateLaptopStoreAsync(LaptopStore store)
        {
            _dbContext.LaptopStores.Update(store);
        }
        public async Task DeleteLaptopStoreAsync(LaptopStore store)
        {
            _dbContext.LaptopStores.Remove(store);
        }
    }
}
