namespace LaptopStores.Application.DTOs
{
    public class UpdateLaptopStoreDto
    {
        public Guid? Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }

        // Address properties
        public string? City { get; set; }
        public string? Street { get; set; }
        public string? Code { get; set; }
        public UpdateLaptopStoreDto() { }
        public UpdateLaptopStoreDto(Guid? _id, string? _name, string? _email, string? _phoneNumber,
                              string? _city, string? _street, string? _code)
        {
            Id = _id;
            Name = _name;
            Email = _email;
            PhoneNumber = _phoneNumber;
            City = _city;
            Street = _street;
            Code = _code;
        }
    }
}
