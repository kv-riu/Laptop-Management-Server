using LaptopStores.Domain.Interfaces;
using LaptopStores.Infrastructure.Persistences;
using LaptopStores.Infrastructure.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LaptopStores.Infrastructure.Extensions //DbContext extension class to add services to the dependency injection container
                                                 //in Program.cs
{
    public static class ServiceExtensionCollection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)//"this" keyword allows us to call this method
                                                                                        //on an instance of IServiceCollection,
                                                                                        //which is the type of the services parameter.
        {
            string connectionString = configuration.GetConnectionString("PostgreSqlLaptopStoresDB");//Get a connection string from the appsettings.json file
                                                                                       //using the key "PostgreSqlLaptopStoresDB".
            services.AddDbContext<LaptopStoresDbContext>(options => options.UseNpgsql(connectionString));
            // - Can add other infrastructure services here, such as repositories, unit of work, etc.
            // - Can hide database connection strings and other configuration details in this method.
            // - For cleaner code, it's a good practice to separate the infrastructure services
            // into different extension methods or classes if there are many services to add.

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}