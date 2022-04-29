namespace Książka_Adresowa;

public class AddressBookManager
{
    private List<AddressBookRecord> addressBookRecords;
    
    public AddressBookManager()
    {
        addressBookRecords = new List<AddressBookRecord>();
    }
    
    public void AddRecord(AddressBookRecord record)
    {
        addressBookRecords.Add(record);
    }
    
    public List<AddressBookRecord> GetRecordsByCity(string city)
    {
        return addressBookRecords.Where(x => x.City == city).ToList();
    }

    public AddressBookRecord? GetLastRecord()
    {
        if(addressBookRecords.Count == 0)
        {
            return null;
        }
        return addressBookRecords[^1];
    }
    
}