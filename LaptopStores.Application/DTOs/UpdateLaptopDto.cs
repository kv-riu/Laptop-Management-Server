using System.Security.Cryptography.X509Certificates;

namespace LaptopStores.Application.DTOs
{
    public class UpdateLaptopDto
    {
        public Guid? Id { get; set; }
        public string? Brand { get; set; }
        public string? Model { get; set; }
        public int? RAM { get; set; }
        public int? Storage { get; set; }
        public string? KeyboardBacklight { get; set; }
        public double? Price { get; set; }
        public UpdateLaptopDto() { }
        public UpdateLaptopDto(Guid? _id, string? _brand, string? _model, int? _ram, 
                                int? _storage, string? _keyboardBacklight, double? _price)
        {
            Id = _id;
            Brand = _brand;
            Model = _model;
            RAM = _ram;
            Storage = _storage;
            KeyboardBacklight = _keyboardBacklight;
            Price = _price;
        }
    }
}
