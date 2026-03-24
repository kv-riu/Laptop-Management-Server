using LaptopStores.Domain.Interfaces;
using LaptopStores.Infrastructure.Repositories;
using LaptopStores.Infrastructure.Persistences;

namespace LaptopStores.Infrastructure.UnitOfWorks
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly LaptopStoresDbContext _dbContext;
        public ILaptopStoreRepository LaptopStoreRepository { get; private set; }
        public ILaptopRepository LaptopRepository { get; private set; } 
        public UnitOfWork(LaptopStoresDbContext db)
        {
            _dbContext = db;
            LaptopStoreRepository = new LaptopStoreRepository(_dbContext);
            LaptopRepository = new LaptopRepository(_dbContext);
        }
        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
         public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
