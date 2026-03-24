using LaptopStores.Domain.Common;
using LaptopStores.Application.DTOs;
using LaptopStores.Domain.Interfaces;

namespace LaptopStores.Application.RemoveLaptopUseCase 
{
    public class ValidRemoveLaptop : IRemoveLaptop
    {
        private readonly IRemoveLaptop _removeLaptop;
        private readonly IUnitOfWork _unitOfWork;

        public ValidRemoveLaptop(IRemoveLaptop removeLaptop, IUnitOfWork unitOfWork)
        {
            _removeLaptop = removeLaptop;
            _unitOfWork = unitOfWork;
        }
        public async Task<Result> RemoveLaptopAsync(Guid storeId, Guid laptopId)
        {
            // Any logic...
            if (storeId == Guid.Empty || laptopId == Guid.Empty)
            {
                // If not use "async" and "await", then return Task.FromResult(Result.Failure(....)), it means return immediately
                return Result.Failure("StoreId and LaptopId cannot be empty.");
            }
            var laptopResult = await _unitOfWork.LaptopRepository.GetLaptopByIdAsync(laptopId);
            if (laptopResult == null)
            {
                return Result.Failure("Laptop with the given ID does not exist.");
            }
            if (laptopResult.StoreId != storeId)
            {
                return Result.Failure("Laptop is not in this store.");
            }
            return await _removeLaptop.RemoveLaptopAsync(storeId, laptopId); //True usecase
        }
    }
}
