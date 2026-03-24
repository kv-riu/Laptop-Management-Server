using LaptopStores.Domain.Common;

namespace LaptopStores.Application.RemoveLaptopUseCase
{
    public interface IRemoveLaptop
    {
        Task<Result> RemoveLaptopAsync(Guid storeId, Guid laptopId);
    }
}
