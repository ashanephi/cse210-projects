public class Address 
{
    private string _streetAddress;
    private string _city;
    private string _state;
    private string _country;

    public Address(string address)
    {
        string[] words = address.Split(",");
        _streetAddress = words[0];
        _city = words[1];
        _state = words[2];
        _country = words[3];        
    }
    public Address(string streetAddress, string city, string state, string country)
    {
        _streetAddress = streetAddress;
        _city = city;
        _state = state;
        _country = country;
    }

    public string getCountry()
    {
        return _country;
    }

    public string GetAddressDetails()
    {
        return $"{_streetAddress}\n\t{_city}, {_state}\n\t{_country}";
    }
    public bool isUSACountry(string country) => country == "USA" || country.ToLower() =="United States of America".ToLower() ? true : false;


}