using LaptopStores.Domain.Entities;
using LaptopStores.Domain.Common;
using LaptopStores.Application.DTOs;
using LaptopStores.Application.Validators;

namespace LaptopStores.Application.LaptopUseCase
{
    internal class ValidLaptopCRUD : ILaptopCRUD
    {
        private readonly ILaptopCRUD _laptopCRUD;
        private readonly IValidator<LaptopDto> _createValidator;
        private readonly IValidator<UpdateLaptopDto> _updateValidator;
        public ValidLaptopCRUD(ILaptopCRUD laptopCRUD, IValidator<LaptopDto> createValidator, IValidator<UpdateLaptopDto> updateValidator)
        {
            _laptopCRUD = laptopCRUD;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public async Task<Result> CreateLaptopAsync(LaptopDto dto)
        {
            Result result = _createValidator.IsValid(dto);
            //Console.WriteLine($"Validation result: IsFailure={result.IsFailure}, Message='{result.Message}'");
            if (result.IsFailure)
            {
                return Result<Laptop>.Failure(result.Message);
            }
            result = await _laptopCRUD.CreateLaptopAsync(dto);
            return Result<Laptop>.Success(result.Message);
        }

        public async Task<Result<FindLaptopDto>> GetLaptopByIdAsync(Guid id)
        {
            return await _laptopCRUD.GetLaptopByIdAsync(id);
        }
        public async Task<Result<IEnumerable<FindLaptopDto>>> GetAllLaptopsAsync()
        {
            return await _laptopCRUD.GetAllLaptopsAsync();
        }
        public async Task<Result> UpdateLaptopAsync(UpdateLaptopDto dto)
        {
            Result result = _updateValidator.IsValid(dto);
            if (result.IsFailure)
            {
                return Result<Laptop>.Failure(result.Message);
            }
            result = await _laptopCRUD.UpdateLaptopAsync(dto);
            return Result<Laptop>.Success(result.Message);
        }
        public async Task<Result> DeleteLaptopAsync(Guid id)
        {
            return await _laptopCRUD.DeleteLaptopAsync(id);
        }
    }
}
