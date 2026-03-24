using LaptopStores.Application.DTOs;
using LaptopStores.Domain.Common;

namespace LaptopStores.Application.Validators
{
    public class CreateLaptopStoreValidator : IValidator<LaptopStoreDto>
    {
        public Result IsValid(LaptopStoreDto dto)
        {
            if (string.IsNullOrEmpty(dto.Name))
            {
                return Result.Failure("Name is required.");
            }
            if (string.IsNullOrEmpty(dto.Email) || !dto.Email.Contains("@"))
            {
                return Result.Failure("A valid email is required.");
            }
            if (string.IsNullOrEmpty(dto.PhoneNumber) || dto.PhoneNumber.Length < 7)
            {
                return Result.Failure("A valid phone number is required.");
            }
            if (string.IsNullOrEmpty(dto.Street))
            {
                return Result.Failure("Street is required.");
            }
            if (string.IsNullOrEmpty(dto.City))
            {
                return Result.Failure("City is required.");
            }
            if (string.IsNullOrEmpty(dto.Code))
            {
                return Result.Failure("Postal code is required.");
            }
            return Result.Success("");
        }
    }
}
