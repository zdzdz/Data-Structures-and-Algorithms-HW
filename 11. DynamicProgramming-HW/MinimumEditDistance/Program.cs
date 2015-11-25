namespace MinimumEditDistance
{
    using System;

    public class StartUp
    {
        private const string FirstString = "developer";
        private const string SecondString = "enveloped";

        public const decimal ReplaceCost = 1.0M;
        public const decimal DeleteCost = 0.9M;
        public const decimal InsertCost = 0.8M;

        public static void Main()
        {
            // https://www.youtube.com/watch?v=gSGf8P8D_uY

            decimal[,] costArray = FindMinimumCost(FirstString, SecondString);

            Console.WriteLine("The minimal sum of costs: {0}", costArray[FirstString.Length, SecondString.Length]);
            PrintArr(costArray);
        }

        private static decimal[,] FindMinimumCost(string firstString, string secondString)
        {
            var m = firstString.Length;
            var n = secondString.Length;
            var cost = new decimal[m + 1, n + 1];

            for (int i = 0; i < cost.GetLength(0); i++)
            {
                cost[i, 0] = i * DeleteCost;
            }

            for (int j = 0; j < cost.GetLength(1); j++)
            {
                cost[0, j] = j * InsertCost;
            }

            for (int i = 1; i <= m; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    var insert = cost[i, j - 1] + InsertCost;
                    var delete = cost[i - 1, j] + DeleteCost;
                    var replace = cost[i - 1, j - 1];

                    if (firstString[i - 1] != secondString[j - 1])
                    {
                        replace += ReplaceCost;
                    }

                    cost[i, j] = Math.Min(replace, Math.Min(insert, delete));
                }
            }
            return cost;
        }

        private static void PrintArr(decimal[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write(string.Format("{0}", array[i, j]).PadRight(5));
                }
                Console.WriteLine();
            }
        }
    }
}