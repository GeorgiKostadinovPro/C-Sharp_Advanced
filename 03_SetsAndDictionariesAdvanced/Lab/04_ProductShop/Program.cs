using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_ProductShop
{
    public class Product
    {
        public Product(string name, double price)
        {
            this.Name = name;
            this.Price = price;
        }

        public string Name { get; set; }

        public double Price { get; set; }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            Dictionary<string, List<Product>> shops = new Dictionary<string, List<Product>>();

            string line = string.Empty;

            while ((line = Console.ReadLine()) != "Revision")
            {
                string[] cmdArgs = line
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);

                string shop = cmdArgs[0];
                string productName = cmdArgs[1];
                double productPrice = double.Parse(cmdArgs[2]);

                if (!shops.ContainsKey(shop))
                {
                    shops.Add(shop, new List<Product>());
                }

                Product product = new Product(productName, productPrice);

                shops[shop].Add(product);
            }

            foreach (var shop in shops.OrderBy(s => s.Key))
            {
                Console.WriteLine($"{shop.Key}->");

                foreach (var product in shop.Value)
                {
                    Console.WriteLine($"Product: {product.Name}, Price: {product.Price}");
                }
            }
        }
    }
}
