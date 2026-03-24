using System.ComponentModel.DataAnnotations;
using System.Data.Common;

namespace LaptopStores.Domain.Entities
{
    public class Laptop
    {
        public Guid Id { get; set; } // Globa Unique identifier for the laptop

        [Required(ErrorMessage = "Brand cannot empty.")]
        public string Brand { get; set; } = "Unknown"; // The brand of the laptop (e.g., Dell, HP, Apple)

        [Required(ErrorMessage = "Model cannot empty.")]
        public string Model { get; set; } = "Unknown"; // The model of the laptop (e.g., XPS 13, MacBook Pro)

        [Range(1, 128, ErrorMessage = "Ram should be between 1 and 128")]
        public int RAM { get; set; } // The amount of RAM in GB

        [Range(128, 8192, ErrorMessage = "Storage should be between 128 and 8192")]
        public int Storage { get; set; } // The amount of storage in GB
        public string? KeyboardBacklight { get; set; } // Indicates whether the laptop has a backlit keyboard (e.g., "Red", "Blue" or NULL)

        [Range(1, double.MaxValue, ErrorMessage = "Price should be positive")]
        public double Price { get; set; } // The price of the laptop in USD

        public Guid? StoreId { get; set; } // Foreign key to the LaptopStore entity, indicating which store the laptop belongs to.

        public LaptopStore? Store { get; set; } // Navigation property to the LaptopStore entity,
                                                     // allowing access to the store details from the laptop.
        public Laptop() { } // Parameterless constructor for Entity Framework
        public Laptop(string brand, string model, int ram, int storage, string? keyboardBacklight, double price, Guid? storeId = null)
        {
            Id = Guid.NewGuid(); // Automatically generate a new unique identifier for each laptop
            Brand = brand;
            Model = model;
            RAM = ram;
            Storage = storage;
            KeyboardBacklight = keyboardBacklight;
            Price = price;
            StoreId = storeId; // Initially, the laptop is not assigned to any store
        }
        public void update(string? brand, string? model, int? ram, int? storage, string? keyboardBacklight, double? price)
        {
            if(brand != null) Brand = brand;
            if(model != null) Model = model;
            if(ram != null) RAM = ram.Value;
            if(storage != null) Storage = storage.Value;
            if(keyboardBacklight != null) KeyboardBacklight = keyboardBacklight;
            if(price != null) Price = price.Value;
        }

        public void assignToStore(Guid storeId)
        {
            StoreId = storeId;
        }

        public void UnassignFromStore()
        {
            StoreId = null;
        }
    }
}
