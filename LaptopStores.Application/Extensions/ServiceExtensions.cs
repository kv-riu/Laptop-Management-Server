using Microsoft.Extensions.DependencyInjection;
using LaptopStores.Application.LaptopStoreUseCase;
using LaptopStores.Application.LaptopUseCase;
using LaptopStores.Application.AddLaptopUseCase;
using LaptopStores.Application.RemoveLaptopUseCase;
using LaptopStores.Application.Validators;
using LaptopStores.Application.DTOs;

using LaptopStores.Domain.Interfaces;
namespace LaptopStores.Application.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            //Validators
            services.AddScoped<IValidator<LaptopDto>, CreateLaptopValidator>();
            services.AddScoped<IValidator<UpdateLaptopDto>, UpdateLaptopValidator>();
            services.AddScoped<IValidator<LaptopStoreDto>, CreateLaptopStoreValidator>();
            services.AddScoped<IValidator<UpdateLaptopStoreDto>, UpdateLaptopStoreValidator>();

            // Laptop Store CRUD    
            services.AddScoped<LaptopStoreCRUD>(); //original usecase
            services.AddScoped<ILaptopStoreCRUD>(provider =>
            {
                var core = provider.GetRequiredService<LaptopStoreCRUD>();
                var createValidator = provider.GetRequiredService<IValidator<LaptopStoreDto>>();
                var updateValidator = provider.GetRequiredService<IValidator<UpdateLaptopStoreDto>>();
                //provider is the service provider that can resolve dependencies from the DI container.
                // GetRequiredService is a method that retrieves a service of the specified type from the DI container.
                // If the service is not registered, it throws an exception.
                return new ValidLaptopStoreCRUD(core, createValidator, updateValidator);
            });

            //Laptop CRUD
            services.AddScoped<LaptopCRUD>(); //original usecase
            services.AddScoped<ILaptopCRUD>(provider =>
            {
                var core = provider.GetRequiredService<LaptopCRUD>();
                var createValidator = provider.GetRequiredService<IValidator<LaptopDto>>();
                var updateValidator = provider.GetRequiredService<IValidator<UpdateLaptopDto>>();
                return new ValidLaptopCRUD(core, createValidator, updateValidator);
            });

            //Add Laptop Use Cases
            services.AddScoped<AddLaptop>(); //original usecase
            services.AddScoped<IAddLaptop>(provider =>
            {
                var core = provider.GetRequiredService<AddLaptop>();
                var unitOfWork = provider.GetRequiredService<IUnitOfWork>();
                return new ValidAddLaptop(core, unitOfWork);
            });

            //Remove Laptop Use Cases
            services.AddScoped<RemoveLaptop>(); //original usecase
            services.AddScoped<IRemoveLaptop>(provider =>
            {
                var core = provider.GetRequiredService<RemoveLaptop>();
                var unitOfWork = provider.GetRequiredService<IUnitOfWork>();
                return new ValidRemoveLaptop(core, unitOfWork);
            });
        }
    }
}
