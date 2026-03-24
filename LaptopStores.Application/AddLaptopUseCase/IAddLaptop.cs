using LaptopStores.Domain.Common;

namespace LaptopStores.Application.AddLaptopUseCase
{
    public interface IAddLaptop
    {
        Task<Result> AddLaptopAsync(Guid storeId, Guid laptopId);
    }
}
