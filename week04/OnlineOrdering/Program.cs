using System;
using System.Collections.Generic;

class Address
{
    private string street;
    private string city;
    private string state;
    private string country;

    public Address(string street, string city, string state, string country)
    {
        this.street = street;
        this.city = city;
        this.state = state;
        this.country = country;
    }

    public bool IsInNigeria()
    {
        return country.Trim().ToUpper() == "NIGERIA";
    }

    public string GetFullAddress()
    {
        return $"{street}\n{city}, {state}\n{country}";
    }
}

class Customer
{
    private string name;
    private Address address;

    public Customer(string name, Address address)
    {
        this.name = name;
        this.address = address;
    }

    public bool IsInNigeria()
    {
        return address.IsInNigeria();
    }

    public string GetName()
    {
        return name;
    }

    public string GetAddressString()
    {
        return address.GetFullAddress();
    }
}

class Product
{
    private string name;
    private string productId;
    private double price;
    private int quantity;

    public Product(string name, string productId, double price, int quantity)
    {
        this.name = name;
        this.productId = productId;
        this.price = price;
        this.quantity = quantity;
    }

    public double GetTotalCost()
    {
        return price * quantity;
    }

    public string GetPackingInfo()
    {
        return $"{name} (ID: {productId})";
    }
}

class Order
{
    private List<Product> products = new List<Product>();
    private Customer customer;

    public Order(Customer customer)
    {
        this.customer = customer;
    }

    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    public double GetTotalCost()
    {
        double total = 0;
        foreach (Product p in products)
        {
            total += p.GetTotalCost();
        }

        // Nigeria = cheap shipping, outside Nigeria = expensive
        total += customer.IsInNigeria() ? 5 : 35;
        return total;
    }

    public string GetPackingLabel()
    {
        string label = "Packing Label:\n";
        foreach (Product p in products)
        {
            label += p.GetPackingInfo() + "\n";
        }
        return label;
    }

    public string GetShippingLabel()
    {
        return $"Shipping Label:\n{customer.GetName()}\n{customer.GetAddressString()}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        // First order: customer in Nigeria
        Address addr1 = new Address("12 Broad Street", "Lagos", "Lagos State", "Nigeria");
        Customer cust1 = new Customer("Emeka Okafor", addr1);
        Order order1 = new Order(cust1);
        order1.AddProduct(new Product("Laptop", "NG1001", 250000, 1));
        order1.AddProduct(new Product("Wireless Mouse", "NG1002", 7500, 2));

        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Price: ₦{order1.GetTotalCost():0.00}\n");

        // Second order: customer outside Nigeria
        Address addr2 = new Address("45 Oxford Street", "London", "England", "UK");
        Customer cust2 = new Customer("Sarah Johnson", addr2);
        Order order2 = new Order(cust2);
        order2.AddProduct(new Product("Smartphone", "NG2001", 180000, 1));
        order2.AddProduct(new Product("Earbuds", "NG2002", 15000, 1));
        order2.AddProduct(new Product("Power Bank", "NG2003", 20000, 1));

        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Price: ₦{order2.GetTotalCost():0.00}");
    }
}
