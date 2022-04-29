using System.Text.Json;
using Książka_Adresowa.Controllers;

namespace Książka_Adresowa.tests;

using NUnit.Framework;

public class AddressBookControllerTest
{
    [Test, Order(1)]
    public void TestGetEmptyAddressBook()
    {
        using var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
        ILogger<AddressBookController> logger = loggerFactory.CreateLogger<AddressBookController>();
        var controller = new AddressBookController(logger);
        var result = controller.GetLastRecord();
        Assert.AreEqual("", result);
    }

    [Test]
    public void TestGetLastNotEmptyRecord()
    {
        using var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
        ILogger<AddressBookController> logger = loggerFactory.CreateLogger<AddressBookController>();
        var controller = new AddressBookController(logger);
        AddressBookRecord first = new AddressBookRecord { Name = "ABC", Surname = "DEF", PhoneNumber = "123456789" };
        AddressBookRecord second = new AddressBookRecord { Name = "GHI", Surname = "JKL", Email = "test@tets.pl" };
        controller.AddContact(first);
        controller.AddContact(second);
        var result = controller.GetLastRecord();
        AddressBookRecord? returned = JsonSerializer.Deserialize<AddressBookRecord>(result);
        Assert.IsNotNull(returned);
        Assert.AreEqual(second.ToString(), returned.ToString());
    }

    [Test]
    public void TestAddRecord()
    {
        using var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
        ILogger<AddressBookController> logger = loggerFactory.CreateLogger<AddressBookController>();
        var controller = new AddressBookController(logger);
        AddressBookRecord record = new AddressBookRecord { Name = "ABC", Surname = "DEF", PhoneNumber = "123456789" };
        var result = controller.AddContact(record);
        Assert.AreEqual("Contact added: " + record.ToString(), result);
    }

    [Test]
    public void TestGetRecordsFromCity()
    {
        using var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
        ILogger<AddressBookController> logger = loggerFactory.CreateLogger<AddressBookController>();
        var controller = new AddressBookController(logger);
        AddressBookRecord[] set = {new AddressBookRecord { Name = "ABC", Surname = "DEF", PhoneNumber = "123456789", City = "Warszawa" },
                                   new AddressBookRecord { Name = "GHI", Surname = "JKL", PhoneNumber = "123456789", City = "Warszawa" },
                                   new AddressBookRecord { Name = "MNO", Surname = "PQR", PhoneNumber = "123456789", City = "Kraków" }};
        controller.AddContact(set[0]);
        controller.AddContact(set[1]);
        controller.AddContact(set[2]);
        var result = controller.GetContactsByCity("Warszawa");
        AddressBookRecord[]? returned = JsonSerializer.Deserialize<AddressBookRecord[]>(result);
        Assert.IsNotNull(returned);
        Assert.IsTrue(2 == returned.Length);
        Assert.AreEqual(set[0].ToString(), returned[0].ToString());
        Assert.AreEqual(set[1].ToString(), returned[1].ToString());
    }
}