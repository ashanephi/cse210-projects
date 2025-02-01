using System;
using System.ComponentModel;

class Program
{
    static void Main(string[] args)
    {
        List<Order> orders;

        Product product1 = new Product("Laptop", 10001, 799.99m, 8);
        Product product2 = new Product("Iphone X", 10002, 299.99m, 2);
        Product product5 = new Product("5G Router", 10005, 5299.00m, 1);
        Product product6 = new Product("Redmi 14C", 10006, 122000.39m, 2);

        Address address1 = new Address("123 Elm Street", "Springfield", "Illinois", "USA");
        Address address2 = new Address("456 Rue de la Paix", "Paris", "Île-de-France", "France");
        Address address3 = new Address("1B Crospil Estate", "Akpabuyo", "Cross River", "Nigeria");

        Customer customer1 = new Customer("John Doe", address1);
        Customer customer2 = new Customer("Jane Smith", address2);
        Customer customer3 = new Customer("Nephi Asha", address3);

        Order order1 = new Order(customer1);
        Order order2 = new Order(customer2);
        Order order3 = new Order(customer3);

        order1.AddProduct(product1);
        order2.AddProduct(product2);
        order3.AddProduct(product5);
        order3.AddProduct(product6);

        orders = new List<Order> {order1, order2, order3};

        for (int index = 0; index < orders.Count; index++)
        {
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine($"Order {index+1}:");
            Console.WriteLine($"{orders[index].packagingLabel()}");
            Console.WriteLine($"{orders[index].shippingLabel()}"); 
            Console.WriteLine($"Total Price: {orders[index].GetTotalPrice():C}");
        }
        Console.WriteLine();

    }
}