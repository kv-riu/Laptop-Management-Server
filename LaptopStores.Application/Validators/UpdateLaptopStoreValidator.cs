using LaptopStores.Application.DTOs;
using LaptopStores.Domain.Common;

namespace LaptopStores.Application.Validators
{
    public class UpdateLaptopStoreValidator : IValidator<UpdateLaptopStoreDto>
    {
        public Result IsValid(UpdateLaptopStoreDto dto)
        {
            if (dto.Name != null && dto.Name == "")
            {
                return Result.Failure("Name can not be an empty string.");
            }
            if (dto.Email != null && !dto.Email.Contains("@"))
            {
                return Result.Failure("A valid email is required.");
            }
            if (dto.PhoneNumber != null && dto.PhoneNumber.Length < 7)
            {
                return Result.Failure("A valid phone number is required.");
            }
            if (dto.Street != null && dto.Street == "")
            {
                return Result.Failure("Street is required.");
            }
            if (dto.City != null && dto.City == "")
            {
                return Result.Failure("City is required.");
            }
            if (dto.Code != null && dto.Code == "")
            {
                return Result.Failure("Postal code is required.");
            }
            return Result.Success("");
        }
    }
}
