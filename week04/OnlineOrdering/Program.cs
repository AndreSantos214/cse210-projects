using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== ORDER SYSTEM ===\n");

        Address address1 = new Address("123 Main Street", "New York", "NY", "USA");
        Customer customer1 = new Customer("John Smith", address1);

        Product product1 = new Product("Laptop", "NB001", 1170.00, 1);
        Product product2 = new Product("Mouse", "MS001", 25.00, 2);
        Product product3 = new Product("Keyboard", "KB001", 80.00, 1);

        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);
        order1.AddProduct(product3);

        Console.WriteLine("FIRST ORDER:\n================\n");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order1.CalculateTotalCost().ToString("F2")}\n");

        Address address2 = new Address("456 Flower Street", "São Paulo", "SP", "Brazil");
        Customer customer2 = new Customer("Andre Santos", address2);

        Product product4 = new Product("Smartphone", "SP001", 800.00, 1);
        Product product5 = new Product("Headphones", "HP001", 150.00, 2);

        Order order2 = new Order(customer2);
        order2.AddProduct(product4);
        order2.AddProduct(product5);

        Console.WriteLine("SECOND ORDER:\n================\n");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order2.CalculateTotalCost().ToString("F2")}");
    }
}