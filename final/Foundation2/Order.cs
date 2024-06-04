using System.Collections.Generic;

class Order
{
    List<Product> _products;
    Customer _customer;

    public Customer Customer => _customer;

    public Order(Customer customer, List<Product> products)
    {
        _customer = customer;
        _products = products;
    }

    public float CalcTotalPrice()
    {
        float total = 0;
        foreach (Product product in _products)
        {
            total += product.CalcCost();
        }
        if (_customer.InUSA())
        {
            total += 5f;
        }
        else
        {
            total += 35f;
        }
        return total;
    }

    public string MakePackLabel()
    {
        string label = "";
        foreach (Product product in _products)
        {
            label += product.MakePackLabel() + "\n";
        }
        return label.Trim();
    }

    public string MakeShipLabel()
    {
        return _customer.MakeShipLabel();
    }
}