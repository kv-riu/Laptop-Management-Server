using LaptopStores.Domain.Entities;
using LaptopStores.Domain.Common;
using LaptopStores.Application.DTOs;
using LaptopStores.Application.Validators;

namespace LaptopStores.Application.LaptopStoreUseCase
{
    public class ValidLaptopStoreCRUD : ILaptopStoreCRUD
    {
        private readonly ILaptopStoreCRUD _laptopStoreCRUD;
        private readonly IValidator<LaptopStoreDto> _createValidator;
        private readonly IValidator<UpdateLaptopStoreDto> _updateValidator;

        public ValidLaptopStoreCRUD(ILaptopStoreCRUD laptopStoreCRUD, IValidator<LaptopStoreDto> createValidator, IValidator<UpdateLaptopStoreDto> updateValidator)
        {
            _laptopStoreCRUD = laptopStoreCRUD;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public async Task<Result> CreateLaptopStoreAsync(LaptopStoreDto dto)
        {
            Result result = _createValidator.IsValid(dto);
            if (result.IsFailure)
            {
                return Result<LaptopStore>.Failure(result.Message);
            }
            result = await _laptopStoreCRUD.CreateLaptopStoreAsync(dto);
            return Result<LaptopStore>.Success(result.Message);
        }

        public async Task<Result<FindLaptopStoreDto>> GetLaptopStoreByIdAsync(Guid id)
        {
            return await _laptopStoreCRUD.GetLaptopStoreByIdAsync(id);
        }

        public async Task<Result<IEnumerable<FindLaptopStoreDto>>> GetAllLaptopStoresAsync()
        {
            return await _laptopStoreCRUD.GetAllLaptopStoresAsync();
        }

        public async Task<Result> UpdateLaptopStoreAsync(UpdateLaptopStoreDto dto)
        {
            Result result = _updateValidator.IsValid(dto);
            if (result.IsFailure)
            {
                return Result<LaptopStore>.Failure(result.Message);
            }
            result = await _laptopStoreCRUD.UpdateLaptopStoreAsync(dto);
            return Result<LaptopStore>.Success(result.Message);
        }

        public async Task<Result> DeleteLaptopStoreAsync(Guid id)
        {
            return await _laptopStoreCRUD.DeleteLaptopStoreAsync(id);
        }
    }
}
