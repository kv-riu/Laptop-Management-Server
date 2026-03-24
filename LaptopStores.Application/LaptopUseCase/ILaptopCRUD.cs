using LaptopStores.Domain.Entities;
using LaptopStores.Application.DTOs;
using LaptopStores.Domain.Common;

namespace LaptopStores.Application.LaptopUseCase
{
    public interface ILaptopCRUD
    {
        Task<Result> CreateLaptopAsync(LaptopDto dto);
        Task<Result<FindLaptopDto>> GetLaptopByIdAsync(Guid id);
        Task<Result<IEnumerable<FindLaptopDto>>> GetAllLaptopsAsync();
        Task<Result> UpdateLaptopAsync(UpdateLaptopDto dto);
        Task<Result> DeleteLaptopAsync(Guid id);
    }
}
