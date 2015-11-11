namespace ProductsCollection
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Wintellect.PowerCollections;

    public class Startup
    {
        private const int NumberOfProducts = 500000;
        private const int NumberOfSearches = 10000;

        public static void Main()
        {
            var collectionOfProducts = new OrderedBag<Product>();

            for (int i = 0; i < NumberOfProducts; i++)
            {
                var product = new Product(RandomGenerator.GetRandomStringWithRandomLength(3, 7),
                    RandomGenerator.RandomDecimalBetween(1, 100));
                collectionOfProducts.Add(product);
            }

            Console.WriteLine("{0} products have been generated!", NumberOfProducts);

            var testSearch = new List<Product>();

            Console.WriteLine("Running {0} searches:", NumberOfSearches);
            for (int i = 0; i < NumberOfSearches; i++)
            {
                testSearch = SearchProductsByRange(collectionOfProducts, RandomGenerator.RandomDecimalBetween(1, 10),
                    RandomGenerator.RandomDecimalBetween(11, 100));

                if (i%100 == 0)
                {
                    Console.Write("=");
                }
            }

            Console.WriteLine("\r\nTotal products matching the last search criteria: {0}", testSearch.Count);
            Console.WriteLine("First 20 products:");
            foreach (var product in testSearch.Take(20))
            {
                Console.WriteLine(product);
            }
        }

        private static List<Product> SearchProductsByRange(OrderedBag<Product> products, decimal startPrice,
            decimal endPrice)
        {
            var startProduct = new Product("First Product", startPrice);
            var endProduct = new Product("End Product", endPrice);
            var searchResult = products.Range(startProduct, true, endProduct, true);

            return searchResult.Take(20).ToList();
        }
    }
}