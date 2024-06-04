class Customer
{
    private string _name;
    private Address _address;

    public Customer(string name, Address address)
    {
        _name = name;
        _address = address;
    }

    public string MakeShipLabel()
    {
        return "Name: " + _name + "\n" + _address.FullAddress();
    }

    public bool InUSA()
    {
        return _address.IsUSA();
    }
}