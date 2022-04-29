namespace Książka_Adresowa;

public class AddressBookRecord
{
    public string Name { get; set; }
    public string? Surname { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }
    public string? City { get; set; }
    public string? Street { get; set; }
    public int? HouseNumber { get; set; }
    public int? ApartmentNumber { get; set; }
    
    public override string ToString()
    {
        return $"{Name}, {Surname}, {PhoneNumber}, {Email}, {City}, {Street}, {HouseNumber}, {ApartmentNumber}";
    }
}