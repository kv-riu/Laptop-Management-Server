using LaptopStores.Domain.Interfaces;
using LaptopStores.Domain.Common;
using LaptopStores.Application.DTOs;

namespace LaptopStores.Application.AddLaptopUseCase
{
    public class AddLaptop : IAddLaptop
    {
        // True implementation of AddLaptop use case
        private readonly IUnitOfWork _unitOfWork;
        public AddLaptop(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Result> AddLaptopAsync(Guid storeId, Guid laptopId)
        {
            // Here you would have the actual logic to add a laptop to the store
            var existingLaptop = await _unitOfWork.LaptopRepository.GetLaptopByIdAsync(laptopId);
            existingLaptop.assignToStore(storeId);
            // "existingStore.Laptops.Add(existingLaptop);" is not necessary if using a tracking context like Entity Framework,
            // as it will automatically track changes to the existingLaptop entity
            // and update the relationship when SaveChangesAsync is called.

            await _unitOfWork.SaveChangesAsync();
            return Result.Success("Laptop added to the store successfully.");
        }
        
    }
}
