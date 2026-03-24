using LaptopStores.Domain.Entities;
using LaptopStores.Domain.Interfaces;
using LaptopStores.Infrastructure.Persistences;
using Microsoft.EntityFrameworkCore;

namespace LaptopStores.Infrastructure.Repositories
{
    internal class LaptopRepository : ILaptopRepository
    {
        private readonly LaptopStoresDbContext _dbContext;
        public LaptopRepository(LaptopStoresDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateLaptopAsync(Laptop laptop)
        {
            await _dbContext.Laptops.AddAsync(laptop);
        }

        public async Task<Laptop?> GetLaptopByIdAsync(Guid id)
        {
            return await _dbContext.Laptops
                .Include(l => l.Store) //left join
                .FirstOrDefaultAsync(l => l.Id == id);
        }

        public async Task<IEnumerable<Laptop>> GetAllLaptopsAsync()
        {
            return await _dbContext.Laptops
                .Include(l => l.Store)
                .ToListAsync();
        }

        public async Task UpdateLaptopAsync(Laptop laptop)
        {
            _dbContext.Laptops.Update(laptop);
        }

        public async Task DeleteLaptopAsync(Laptop laptop)
        {
            _dbContext.Laptops.Remove(laptop);
        }
    }
}
