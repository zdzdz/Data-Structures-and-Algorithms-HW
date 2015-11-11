namespace TradeCompany
{
    using System;
    using System.Diagnostics;

    public class Startup
    {
        private static readonly Random rand = new Random();
        private static readonly Stopwatch stopWatch = new Stopwatch();

        public static void Main()
        {
            var store = new Store();

            Console.Write("Please wait... ");

            stopWatch.Start();
            AddProducts(store); // 500 000 products
            stopWatch.Stop();

            Console.WriteLine("\rAdding products -> Elapsed time: {0}", stopWatch.Elapsed);

            stopWatch.Restart();
            SearchProductsInPriceRange(store); // 5 000 000 price searches
            stopWatch.Stop();

            Console.WriteLine("\nSearching products -> Elapsed time: {0}\n", stopWatch.Elapsed);
        }

        private static void AddProducts(Store store, int numOfProductsToAdd = 500000)
        {
            for (int i = 0; i < numOfProductsToAdd; i++)
            {
                string title = rand.Next(int.MaxValue).ToString();
                decimal price = rand.Next(20000) / 100;
                store.AddProduct(new Product(title, price));
            }
        }

        private static void SearchProductsInPriceRange(Store store, int numOfProductsToSearch = 5000000)
        {
            for (int i = 0; i < numOfProductsToSearch; i++)
            {
                int min = rand.Next(200), max = rand.Next(250, 2000);
                store.SearchInPriceRange(min, max);
            }
        }
    }
}
