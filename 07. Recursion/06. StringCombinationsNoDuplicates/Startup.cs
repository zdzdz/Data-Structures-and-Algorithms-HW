namespace StringCombinationsNoDuplicates
{
    using System;

    public class Startup
    {
        private static string[] values;
        private static string[] bytes;
        private static int n;
        private static int k;

        public static void Main()
        {
            while (true)
            {
                Console.Write("N = ");
                n = int.Parse(Console.ReadLine());
                Console.Write("K = ");
                k = int.Parse(Console.ReadLine());
                Console.WriteLine();
                values = new string[n];
                bytes = new string[k];
                for (int i = 0; i < n; i++)
                {
                    Console.Write("n[{0}] = ", i);
                    values[i] = Console.ReadLine();
                }

                Console.WriteLine(new string('=', 50));
                Combinations(0, 0);
                Console.WriteLine(new string('=', 50));
            }
        }

        private static void Combinations(int index, int setIndex)
        {
            if (index == bytes.Length)
            {
                Console.WriteLine("({0})", string.Join(", ", bytes));
                return;
            }

            for (int i = setIndex; i < values.Length; i++)
            {
                bytes[index] = values[i];
                Combinations(index + 1, i + 1);
            }
        }
    }
}
