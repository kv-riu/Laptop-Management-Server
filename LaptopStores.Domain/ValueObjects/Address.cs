namespace LaptopStores.Domain.ValueObjects
{
    public class Address
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string Code { get; set; }

        public Address(string street, string city, string code)
        {
            Street = street;
            City = city;
            Code = code;
        }
    }
}
