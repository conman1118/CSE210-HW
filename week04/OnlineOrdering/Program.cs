using System;
using System.Collections.Generic;

namespace Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            // ---- Order 1 ----
            var address1 = new Address(
                street: "123 Main St",
                city:   "Phoenix",
                stateOrProvince: "AZ",
                country: "USA"
            );
            var customer1 = new Customer("Alice Johnson", address1);
            var products1 = new List<Product>
            {
                new Product("Wireless Mouse", "WM1001", 25.99m, 2),
                new Product("USB-C Charger",  "UC2002", 19.50m, 1)
            };
            var order1 = new Order(customer1, products1);

            Console.WriteLine(order1.GetPackingLabel());
            Console.WriteLine(order1.GetShippingLabel());
            Console.WriteLine($"Total Price: ${order1.CalculateTotalCost():0.00}");
            Console.WriteLine();

            // ---- Order 2 ----
            var address2 = new Address(
                street: "456 Elm Road",
                city:   "Toronto",
                stateOrProvince: "ON",
                country: "Canada"
            );
            var customer2 = new Customer("Bob Smith", address2);
            var products2 = new List<Product>
            {
                new Product("Coffee Beans",    "CB3003", 15.00m, 3),
                new Product("Espresso Maker",  "EM4004", 89.99m, 1),
                new Product("Travel Mug",      "TM5005", 12.25m, 2)
            };
            var order2 = new Order(customer2, products2);

            Console.WriteLine(order2.GetPackingLabel());
            Console.WriteLine(order2.GetShippingLabel());
            Console.WriteLine($"Total Price: ${order2.CalculateTotalCost():0.00}");
        }
    }
}
