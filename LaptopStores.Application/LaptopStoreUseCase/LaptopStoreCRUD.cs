using LaptopStores.Application.DTOs;
using LaptopStores.Domain.Common;
using LaptopStores.Domain.Entities;
using LaptopStores.Domain.Interfaces;
using LaptopStores.Domain.ValueObjects;
using static System.Formats.Asn1.AsnWriter;

namespace LaptopStores.Application.LaptopStoreUseCase
{
    public class LaptopStoreCRUD : ILaptopStoreCRUD
    {
        private readonly IUnitOfWork _unitOfWork;
        public LaptopStoreCRUD(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Result> CreateLaptopStoreAsync(LaptopStoreDto dto)
        {
            LaptopStore store = new LaptopStore(
                dto.Name,
                dto.Email,
                dto.PhoneNumber,
                new Address(
                    dto.Street,
                    dto.City,
                    dto.Code
                ));
            await _unitOfWork.LaptopStoreRepository.AddLaptopStoreAsync(store);
            await _unitOfWork.SaveChangesAsync();
            return Result.Success("Laptop store created successfully! Store ID is: " + store.Id);
        }
        public async Task<Result<FindLaptopStoreDto>> GetLaptopStoreByIdAsync(Guid id)
        {
            var store = await _unitOfWork.LaptopStoreRepository.GetLaptopStoreByIdAsync(id);
            if (store == null)
            {
                return Result<FindLaptopStoreDto>.Failure("Laptop store not found.");
            }
            var foundStore = new FindLaptopStoreDto(
                store.Id,
                store.Name,
                store.Email,
                store.PhoneNumber,
                store.Address.City,
                store.Address.Street,
                store.Address.Code
            );
            return Result<FindLaptopStoreDto>.Success(foundStore, "Laptop store retrieved successfully.");
        }
        public async Task<Result<IEnumerable<FindLaptopStoreDto>>> GetAllLaptopStoresAsync()
        {
            var stores = await _unitOfWork.LaptopStoreRepository.GetAllLaptopStoresAsync();
            var storeDtos = stores.Select(store => new FindLaptopStoreDto(
                store.Id,
                store.Name,
                store.Email,
                store.PhoneNumber,
                store.Address.City,
                store.Address.Street,
                store.Address.Code
            ));
            return Result<IEnumerable<FindLaptopStoreDto>>.Success(storeDtos, "All stores retrieved successfully.");
        }
        public async Task<Result> UpdateLaptopStoreAsync(UpdateLaptopStoreDto dto)
        {
            var existingStore = await _unitOfWork.LaptopStoreRepository.GetLaptopStoreByIdAsync(dto.Id.Value);
            if (existingStore == null)
            {
                return Result.Failure("Laptop store not found!");
            }
            existingStore.update(dto.Name, dto.Email, dto.PhoneNumber, 
                     new Address(dto.Street, dto.City, dto.Code));
            await _unitOfWork.SaveChangesAsync();
            return Result.Success("Laptop store updated successfully!");
        }
        public async Task<Result> DeleteLaptopStoreAsync(Guid id)
        {
            var existingStore = await _unitOfWork.LaptopStoreRepository.GetLaptopStoreByIdAsync(id);
            if (existingStore == null)
            {
                return Result.Failure("Laptop store not found!");
            }
            foreach (var laptop in existingStore.Laptops)
            {
                laptop.UnassignFromStore();
            }
            await _unitOfWork.LaptopStoreRepository.DeleteLaptopStoreAsync(existingStore);
            return Result.Success("Laptop store deleted successfully!");
        }
    }
}
