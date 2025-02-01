public class Customer 
{
    private string _name;
    private Address _address;

    public Customer(string name, string address)
    {
        _name = name;
        _address = new Address(address);
    }

    public Customer(string name, Address address)
    {
        _name = name;
        _address = address;
    }

    public string GetCustomerName()
    {
        return _name;
    }

    public Address GetCustomerAddress()
    {
        return _address;
    }

    public bool isCustomerLivingInUSA() => _address.isUSACountry(_address.getCountry()) ? true : false;

}