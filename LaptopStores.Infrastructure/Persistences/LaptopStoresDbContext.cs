using Microsoft.EntityFrameworkCore;
using LaptopStores.Domain.Entities; // Import the namespace where the Laptop entity is defined

namespace LaptopStores.Infrastructure.Persistences
{
    internal class LaptopStoresDbContext : DbContext // Will be name of database
    {
        internal DbSet<LaptopStore> LaptopStores { get; set; } // LaptopStores table in database
        internal DbSet<Laptop> Laptops { get; set; } // Laptops table in database

        public LaptopStoresDbContext(DbContextOptions<LaptopStoresDbContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseNpgsql(); // Use Postgres database
            // Have to migrations to create the database and tables based on the entities defined in the code (use MS.EF.Tools)
            /*
                - Open the Package Manager Console in Visual Studio (Tools > NuGet Package Manager > Package Manager Console).
                - Run the command: Add-Migration <Named-Database-Migration>
                  This will create a new migration named "Named-Database-Migration" based on the current model defined in the LaptopStoresDbContext.
                - After the migration is created, run the command: Update-Database
                - If you want to remove this migration, you can run the command: Remove-Migration

            */
            // Don't need to specify the connection string here because it's
            // already configured in the Program.cs file using the AddInfrastructureServices extension method.
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LaptopStore>()
                .OwnsOne(store => store.Address); // Configure the Address property of LaptopStore as an owned entity,
                                                  // meaning it will be stored in the same table as LaptopStore rather than a separate table.
                                                  // This is useful for value objects that are closely related to the parent entity
                                                  // and do not require their own identity. (1-1 relationship) 
            modelBuilder.Entity<LaptopStore>()
                .HasMany(store => store.Laptops) // Configure the relationship between LaptopStore and Laptop entities,
                                                 // indicating that a LaptopStore can have many Laptops.
                .WithOne(l => l.Store) // Configure the relationship to be one-to-many, meaning each Laptop belongs to one LaptopStore (1-n relationship).
                .HasForeignKey(l => l.StoreId) // Specify the foreign key property in the Laptop entity that will reference the LaptopStore entity.
                .IsRequired(false) // Configure the foreign key to be optional, allowing a Laptop to exist without being assigned to a LaptopStore.
                .OnDelete(DeleteBehavior.SetNull); // Configure the delete behavior to setnull. Laptop still exist but not belong to any store when the store is deleted.

        }
    }
}
