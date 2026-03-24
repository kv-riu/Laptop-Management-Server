using LaptopStores.Domain.Common;
using LaptopStores.Application.DTOs;

namespace LaptopStores.Application.LaptopStoreUseCase
{
    public interface ILaptopStoreCRUD
    {
        Task<Result> CreateLaptopStoreAsync(LaptopStoreDto dto);
        Task<Result<FindLaptopStoreDto>> GetLaptopStoreByIdAsync(Guid id);
        Task<Result<IEnumerable<FindLaptopStoreDto>>> GetAllLaptopStoresAsync();
        Task<Result> UpdateLaptopStoreAsync(UpdateLaptopStoreDto dto);
        Task<Result> DeleteLaptopStoreAsync(Guid id);
    }
}
