using Microsoft.AspNetCore.Mvc;

namespace Książka_Adresowa.Controllers;

[ApiController]
[Route("/")]
public class AddressBookController : ControllerBase
{
    private readonly ILogger<AddressBookController> _logger;
    
    public AddressBookController(ILogger<AddressBookController> logger)
    {
        _logger = logger;
    }
    
    [HttpGet(Name="GetAddressBook")]
    public string GetLastRecord()
    {
        _logger.LogInformation("GetLastRecord");
        return "Hello World";
    }

    [HttpPost("/")]
    public string AddContact([FromBody] AddressBookRecord contact)
    {
        _logger.LogInformation("AddContact");
        string report = $"{contact.Name} {contact.Surname} {contact.PhoneNumber} {contact.Email} {contact.City} {contact.Street} {contact.HouseNumber} {contact.ApartmentNumber}";
        return "Contact added: " + report;
    }
    
    [HttpGet("/{city}")]
    public string GetContactsByCity(string city)
    {
        _logger.LogInformation("GetContactsByCity");
        return "Contacts from " + city;
    }
}