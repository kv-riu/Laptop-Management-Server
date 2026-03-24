using LaptopStores.Application.AddLaptopUseCase;
using LaptopStores.Application.DTOs;
using LaptopStores.Domain.Interfaces;
using LaptopStores.Domain.Common;

namespace LaptopStores.Application.RemoveLaptopUseCase
{
    public class RemoveLaptop : IRemoveLaptop
    {
        private readonly IUnitOfWork _unitOfWork;
        public RemoveLaptop(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> RemoveLaptopAsync(Guid storeId, Guid laptopId)
        {
            var existingLaptop = await _unitOfWork.LaptopRepository.GetLaptopByIdAsync(laptopId);
            existingLaptop.UnassignFromStore();
            await _unitOfWork.SaveChangesAsync();
            return Result.Success("Laptop removed from the store successfully.");
        }
    }
}
