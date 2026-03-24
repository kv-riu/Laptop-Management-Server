using LaptopStores.Domain.Common;
using LaptopStores.Application.DTOs;
using LaptopStores.Domain.Interfaces;

namespace LaptopStores.Application.AddLaptopUseCase
{
    public class ValidAddLaptop : IAddLaptop
    {
        private readonly IAddLaptop _addLaptop;
        private readonly IUnitOfWork _unitOfWork;
        public ValidAddLaptop(IAddLaptop addLaptop, IUnitOfWork unitOfWork)
        {
            _addLaptop = addLaptop;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> AddLaptopAsync(Guid storeId, Guid laptopId)
        {
            // Any logic...
            if(storeId == Guid.Empty || laptopId == Guid.Empty)
            {
                // If not use "async" and "await", then return Task.FromResult(Result.Failure(....)), it means return immediately
                return Result.Failure("StoreId and LaptopId cannot be empty.");
            }
            var laptopResult = await _unitOfWork.LaptopRepository.GetLaptopByIdAsync(laptopId);
            if (laptopResult == null)
            {
                return Result.Failure("Laptop with the given ID does not exist.");
            }
            if(laptopResult.StoreId != null)
            {
                return Result.Failure("Laptop is already assigned to a store.");
            }
            return await _addLaptop.AddLaptopAsync(storeId, laptopId); //True usecase
        }
    }
}
