namespace LaptopStores.Application.DTOs
{
    public class LaptopDto
    {
        public string? Brand { get; set; }
        public string? Model { get; set; }
        public int? RAM { get; set; }
        public int? Storage { get; set; }
        public string? KeyboardBacklight { get; set; }
        public double? Price { get; set; }
        public LaptopDto() { } // Parameterless constructor for deserialization
        // server receive JSON -> Create an empty LaptopDto -> use setter to set the properties
        public LaptopDto(string? _brand, string? _model, int? _ram, int? _storage,
                         string? _keyboardBacklight, double? _price) // not necessary
        {
            Brand = _brand;
            Model = _model;
            RAM = _ram;
            Storage = _storage;
            KeyboardBacklight = _keyboardBacklight;
            Price = _price;
        }
    }
}
