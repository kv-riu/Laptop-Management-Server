using LaptopStores.Domain.Entities;
using LaptopStores.Domain.Interfaces;
using LaptopStores.Application.DTOs;
using LaptopStores.Domain.Common;

namespace LaptopStores.Application.LaptopUseCase
{
    public class LaptopCRUD : ILaptopCRUD
    {
        private readonly IUnitOfWork _unitOfWork;
        public LaptopCRUD(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Result> CreateLaptopAsync(LaptopDto dto)
        {
            Laptop laptop = new Laptop(
                dto.Brand,
                dto.Model,
                dto.RAM.Value,
                dto.Storage.Value,
                dto.KeyboardBacklight,
                dto.Price.Value,
                null
                );
            await _unitOfWork.LaptopRepository.CreateLaptopAsync(laptop);
            await _unitOfWork.SaveChangesAsync();
            return Result.Success("Laptop created successfully! Laptop ID is: " + laptop.Id);
        }
        public async Task<Result<FindLaptopDto>> GetLaptopByIdAsync(Guid id)
        {
            var laptop = await _unitOfWork.LaptopRepository.GetLaptopByIdAsync(id);
            if (laptop == null)
            {
                return Result<FindLaptopDto>.Failure("Laptop not found!");
            }
            var foundLaptop =  new FindLaptopDto(
                laptop.Id,
                laptop.Brand,
                laptop.Model,
                laptop.RAM,
                laptop.Storage,
                laptop.KeyboardBacklight,
                laptop.Price,
                laptop.StoreId,
                laptop.Store?.Name
                );
            return Result<FindLaptopDto>.Success(foundLaptop, "Laptop retrieved successfully.");
        }
        public async Task<Result<IEnumerable<FindLaptopDto>>> GetAllLaptopsAsync()
        {
            var laptops = await _unitOfWork.LaptopRepository.GetAllLaptopsAsync();
            var laptopDtos = laptops.Select(l => new FindLaptopDto(
                l.Id,
                l.Brand,
                l.Model,
                l.RAM,
                l.Storage,
                l.KeyboardBacklight,
                l.Price,
                l.StoreId,
                l.Store?.Name
            ));
            return Result<IEnumerable<FindLaptopDto>>.Success(laptopDtos, "All laptops retrieved successfully.");
        }
        public async Task<Result> UpdateLaptopAsync(UpdateLaptopDto dto)
        {
            var existingLaptop = await _unitOfWork.LaptopRepository.GetLaptopByIdAsync(dto.Id.Value);
            if (existingLaptop == null)
            {
                return Result.Failure("Laptop not found!");
            }
            //Console.WriteLine($"Updating Laptop ID: {existingLaptop.Id}");
            existingLaptop.update(dto.Brand, dto.Model, dto.RAM, 
                                  dto.Storage, dto.KeyboardBacklight, dto.Price);
            // No need to call an update method on the repository if using a tracking context like Entity Framework
            await _unitOfWork.SaveChangesAsync();
            return Result.Success("Laptop updated successfully!");
        }
        public async Task<Result> DeleteLaptopAsync(Guid id)
        {
            var existingLaptop = await _unitOfWork.LaptopRepository.GetLaptopByIdAsync(id);
            if (existingLaptop == null)
            {
                return Result.Failure("Laptop not found!");
            }
            await _unitOfWork.LaptopRepository.DeleteLaptopAsync(existingLaptop);
            await _unitOfWork.SaveChangesAsync();
            return Result.Success("Laptop deleted successfully!");
        }
    }
}
