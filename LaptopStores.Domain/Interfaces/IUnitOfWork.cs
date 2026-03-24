// Use Unit Of Work pattern to manage database transactions and repositories in a consistent way.
namespace LaptopStores.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        // Define repositories for each entity
        ILaptopStoreRepository LaptopStoreRepository { get; } // Not a field, just a "promise".
                                                              // Inherited class from this must implement this property
                                                              // to return an instance of ILaptopStoreRepository.
        ILaptopRepository LaptopRepository { get; }

        Task<int> SaveChangesAsync();
    }
}
