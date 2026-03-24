using LaptopStores.Domain.Common;

namespace LaptopStores.Application.Validators
{
    public interface IValidator<T>
    {
        Result IsValid(T dto);
    }
}
