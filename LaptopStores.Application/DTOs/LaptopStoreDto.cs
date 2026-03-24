namespace LaptopStores.Application.DTOs
{
    public class LaptopStoreDto
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }

        // Address properties
        public string? City { get; set; }
        public string? Street { get; set; }
        public string? Code { get; set; }
        public LaptopStoreDto() { }
        public LaptopStoreDto(string? _name, string? _email, string? _phoneNumber,
                              string? _city, string? _street, string? _code)
        {
            Name = _name;
            Email = _email;
            PhoneNumber = _phoneNumber;
            City = _city;
            Street = _street;
            Code = _code;
        }
    }
}
