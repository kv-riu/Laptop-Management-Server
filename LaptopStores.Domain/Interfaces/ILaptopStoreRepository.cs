using LaptopStores.Domain.Entities;

namespace LaptopStores.Domain.Interfaces
{
    public interface ILaptopStoreRepository
    {
        Task<LaptopStore?> GetLaptopStoreByIdAsync(Guid id);
        Task<IEnumerable<LaptopStore>> GetAllLaptopStoresAsync(); // List is an implementation of IEnumerable
        Task AddLaptopStoreAsync(LaptopStore laptopStore);
        Task UpdateLaptopStoreAsync(LaptopStore laptopStore);
        Task DeleteLaptopStoreAsync(LaptopStore laptopStore);
    }
}
