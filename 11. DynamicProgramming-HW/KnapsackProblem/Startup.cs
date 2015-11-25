namespace KnapsackProblem
{
    using System;

    public class Startup
    {
        private static int maxCapacity = 10;

        static void Main()
        {
            var beer = new Product("Beer", 3, 2);
            var vodka = new Product("Vodka", 8, 12);
            var cheese = new Product("Cheese", 4, 5);
            var nuts = new Product("Nuts", 1, 4);
            var ham = new Product("Ham", 2, 3);
            var whiskey = new Product("Whiskey", 8, 13);

            Product[] products = {beer, vodka, cheese, nuts, ham, whiskey};
            var array = FindMaxCostInKnapsack(products);

            PrintArr(array);
            Console.WriteLine("Result:");
            PrintProducts(products.Length, maxCapacity, array, products);
        }

        private static int[,] FindMaxCostInKnapsack(Product[] products)
        {
            int numberOfProducts = products.Length;
            var arr = new int[numberOfProducts + 1, maxCapacity];
            for (int j = 0; j < maxCapacity; j++)
            {
                arr[0, j] = 0;
            }

            for (int i = 1; i <= products.Length; i++)
            {
                for (int j = 0; j < maxCapacity; j++)
                {
                    if (products[i - 1].Weight <= j)
                    {
                        arr[i, j] = Math.Max(arr[i - 1, j],
                            arr[i - 1, j - products[i - 1].Weight] + products[i - 1].Cost);
                    }
                    else
                    {
                        arr[i, j] = arr[i - 1, j];
                    }
                }
            }
            Console.WriteLine(arr[numberOfProducts, maxCapacity - 1]);
            return arr;
        }

        private static void PrintArr(int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write(string.Format("{0}", array[i, j]).PadRight(3));
                }
                Console.WriteLine();
            }
        }

        private static void PrintProducts(int i, int j, int[,] array, Product[] products)
        {
            while (i != 0 && j != 0)
            {
                if (array[i, j - 1] != array[i - 1, j - 1])
                {
                    Console.WriteLine(products[i - 1]);
                    var currentcost = array[i, j - 1] - products[i - 1].Cost;
                    while (array[i, j - 1] != currentcost)
                    {
                        j--;
                    }
                }
                else
                {
                    i--;
                }
            }
        }
    }
}
