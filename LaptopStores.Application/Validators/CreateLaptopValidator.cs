using LaptopStores.Application.DTOs;
using LaptopStores.Domain.Common;

namespace LaptopStores.Application.Validators
{
    public class CreateLaptopValidator : IValidator<LaptopDto>
    {
        public Result IsValid(LaptopDto dto)
        {
            if(string.IsNullOrEmpty(dto.Brand))
            {
                return Result.Failure("Brand is required.");
            }
            if(string.IsNullOrEmpty(dto.Model))
            {
                return Result.Failure("Model is required.");
            }
            if(dto.RAM == null || dto.RAM <= 0 || dto.RAM > 128)
            {
                return Result.Failure("RAM must be an integer between 1 and 128.");
            }
            if(dto.Storage == null || dto.Storage <= 0)
            {
                return Result.Failure("Storage must be an integer between 1 and 128.");
            }
            if (dto.Price == null || dto.Price <= 0.0)
            {
                return Result.Failure("Price must be positive");
            }
            return Result.Success("");
        }
    }
}
