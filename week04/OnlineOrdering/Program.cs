using System;

class Program
{
    static void Main(string[] args)
    {
        // Customer in Nigeria
        Address addr1 = new Address("12 Broad Street", "Lagos", "Lagos", "Nigeria");
        Customer cust1 = new Customer("Chinedu Okafor", addr1);
        Order order1 = new Order(cust1);
        order1.AddProduct(new Product("Laptop", "P1001", 350000, 1));
        order1.AddProduct(new Product("Mouse", "P1002", 5000, 2));

        // Customer outside Nigeria
        Address addr2 = new Address("742 Evergreen Terrace", "Springfield", "IL", "USA");
        Customer cust2 = new Customer("John Smith", addr2);
        Order order2 = new Order(cust2);
        order2.AddProduct(new Product("Book", "P2001", 20, 3));
        order2.AddProduct(new Product("Pen", "P2002", 2, 10));

        // Display results
        DisplayOrder(order1);
        Console.WriteLine();
        DisplayOrder(order2);
    }

    static void DisplayOrder(Order order)
    {
        Console.WriteLine(order.GetPackingLabel());
        Console.WriteLine(order.GetShippingLabel());
        Console.WriteLine($"Total Cost: {order.GetTotalCost()}");
    }
}
