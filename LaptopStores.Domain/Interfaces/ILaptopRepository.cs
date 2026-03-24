using LaptopStores.Domain.Entities;

namespace LaptopStores.Domain.Interfaces
{
    public interface ILaptopRepository
    {
        Task<Laptop?> GetLaptopByIdAsync(Guid id);
        Task<IEnumerable<Laptop>> GetAllLaptopsAsync();
        Task CreateLaptopAsync(Laptop laptop);
        Task UpdateLaptopAsync(Laptop laptop);
        Task DeleteLaptopAsync(Laptop laptop);
    }
}
