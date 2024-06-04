using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Address addy1 = new Address("2013 Connemara Dr", "Gilbert", "AZ", "USA");
        Customer person1 = new Customer("Shirley", addy1);
        List<Product> products1 = new List<Product>();
        Product product1 = new Product("Lomo Saltado", 101, 2.25f, 1);
        Product product2 = new Product("Aji de Gallina", 102, 3.75f, 2);
        products1.Add(product1);
        products1.Add(product2);
        Order order1 = new Order(person1, products1);

        Console.WriteLine("Order 1");
        Console.WriteLine("--------------------------------------");

        foreach (var product in products1)
        {
            Console.WriteLine($"{product.Quantity} x {product.Price:C}");
            Console.WriteLine($"{product.ProductID,-3}\t{ToTitleCase(product.Name),-20}\t{product.Price:C}");
        }

        float subtotal1 = order1.CalcTotalPrice() - (order1.Customer.InUSA() ? 5f : 35f);
        float shippingCost1 = order1.Customer.InUSA() ? 5f : 35f;

        Console.WriteLine("--------------------------------------");
        Console.WriteLine($"SUBTOTAL{subtotal1,29:C}");
        Console.WriteLine($"SHIPPING COST{shippingCost1,24:C}");
        Console.WriteLine($"TOTAL{order1.CalcTotalPrice(),33:C}");
        Console.WriteLine("--------------------------------------");

        Console.WriteLine("PACKING LABEL");
        Console.WriteLine(order1.MakePackLabel());
        Console.WriteLine("--------------------------------------");

        Console.WriteLine("SHIPPING LABEL");
        Console.WriteLine(order1.MakeShipLabel());
        Console.WriteLine("--------------------------------------");

        Console.WriteLine("//////////////////////////////////////");

        Address addy2 = new Address("2196 Rome St", "Ottawa", "ON", "CANADA");
        Customer person2 = new Customer("Chad", addy2);
        List<Product> products2 = new List<Product>();
        Product product3 = new Product("Alfajores", 103, 4.75f, 2);
        Product product4 = new Product("Tres Leches", 104, 3.25f, 1);
        products2.Add(product3);
        products2.Add(product4);
        Order order2 = new Order(person2, products2);

        Console.WriteLine("Order 2");
        Console.WriteLine("--------------------------------------");

        foreach (var product in products2)
        {
            Console.WriteLine($"{product.Quantity} x {product.Price:C}");
            Console.WriteLine($"{product.ProductID,-3}\t{ToTitleCase(product.Name),-20}\t{product.Price:C}");
        }

        float subtotal2 = order2.CalcTotalPrice() - (order2.Customer.InUSA() ? 5f : 35f);
        float shippingCost2 = order2.Customer.InUSA() ? 5f : 35f;

        Console.WriteLine("--------------------------------------");
        Console.WriteLine($"SUBTOTAL{subtotal2,30:C}");
        Console.WriteLine($"SHIPPING COST{shippingCost2,25:C}");
        Console.WriteLine($"TOTAL{order2.CalcTotalPrice(),33:C}");
        Console.WriteLine("--------------------------------------");

        Console.WriteLine("PACKING LABEL");
        Console.WriteLine(order2.MakePackLabel());
        Console.WriteLine("--------------------------------------");
        Console.WriteLine("SHIPPING LABEL");
        Console.WriteLine(order2.MakeShipLabel());
        Console.WriteLine("--------------------------------------");
    }

    static string ToTitleCase(string str)
    {
        if (str.Length < 2)
            return str.ToUpper();
        return char.ToUpper(str[0]) + str.Substring(1).ToLower();
    }
}