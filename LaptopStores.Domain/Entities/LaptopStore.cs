using LaptopStores.Domain.ValueObjects;

namespace LaptopStores.Domain.Entities
{
    public class LaptopStore
    {
        public Guid Id { get; set; } //Unique identifier for the laptop store.
        public string Name { get; set; } 
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }

        public Address Address { get; set; }

        public List<Laptop> Laptops { get; set; } = new(); //List of laptops available in the store, initialized to an empty list.
        public LaptopStore(string name, string? email, string? phoneNumber, Address address)
         {
            Id = Guid.NewGuid();
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
            Address = address;
        }
        private LaptopStore() { } // Parameterless constructor for EF Core
        public void update(string? _name, string? _email, string? _phoneNumber, Address? _address)
        {
            if (_name != null) Name = _name;
            if (_email != null) Email = _email;
            if (_phoneNumber != null) PhoneNumber = _phoneNumber;
            if (_address != null) Address = _address;
        }
        public void addLaptop(Laptop laptop)
        {
            Laptops.Add(laptop);
            laptop.assignToStore(Id);
        }
        public void removeLaptop(Laptop laptop)
        {
            Laptops.Remove(laptop);
            laptop.UnassignFromStore();
        }
    }
}
