using LaptopStores.Application.DTOs;
using LaptopStores.Domain.Common;

namespace LaptopStores.Application.Validators
{
    public class UpdateLaptopValidator : IValidator<UpdateLaptopDto>
    {
        public Result IsValid(UpdateLaptopDto dto)
        {
            //if (Guid.)
            //{
            //    return Result.Failure("Id is required.");
            //}
            if (dto.Brand != null && dto.Brand == "")
            {
                return Result.Failure("Brand can not be an empty string");
            }
            if (dto.Model != null && dto.Model == "")
            {
                return Result.Failure("Model can not be an empty string");
            }
            if (dto.RAM != null && dto.RAM <= 0 || dto.RAM > 128)
            {
                return Result.Failure("RAM must be an integer between 1 and 128.");
            }
            if (dto.Storage != null && dto.Storage <= 0 || dto.Storage > 8192)
            {
                return Result.Failure("Storage must be an integer between 1 and 8192.");
            }
            if (dto.Price != null && dto.Price <= 0.0)
            {
                return Result.Failure("Price must be positive");
            }
            return Result.Success("");
        }
    }
}
