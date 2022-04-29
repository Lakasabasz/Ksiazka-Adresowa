using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace Książka_Adresowa.Controllers;

[ApiController]
[Route("/")]
public class AddressBookController : ControllerBase
{
    private readonly ILogger<AddressBookController> _logger;
    private static AddressBookManager _addressBook = new AddressBookManager();
    
    public AddressBookController(ILogger<AddressBookController> logger)
    {
        _logger = logger;
    }
    
    [HttpGet(Name="GetAddressBook")]
    public string GetLastRecord()
    {
        _logger.LogInformation("[{Time}] GetLastRecord", DateTime.Now);
        AddressBookRecord? record = _addressBook.GetLastRecord();
        if (record == null)
        {
            return "";
        }
        return JsonSerializer.Serialize(record);
    }

    [HttpPost("/")]
    public string AddContact([FromBody] AddressBookRecord contact)
    {
        _logger.LogInformation("[{Time}] AddContact {Contact}", DateTime.Now, contact);
        _addressBook.AddRecord(contact);
        return "Contact added: " + contact;
    }
    
    [HttpGet("/{city}")]
    public string GetContactsByCity(string city)
    {
        _logger.LogInformation("[{Time}] GetContactsByCity: {City}", DateTime.Now, city);
        List<AddressBookRecord> records = _addressBook.GetRecordsByCity(city);
        return JsonSerializer.Serialize(records);
    }
}