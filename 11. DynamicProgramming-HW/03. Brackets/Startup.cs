namespace Brackets
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            var symbols = Console.ReadLine();
            int N = symbols.Length;
            long[,] result = new long[N + 1, N + 2];
            result[0, 0] = 1;

            for (int k = 1; k <= N; k++)
            {
                if (symbols[k - 1] == '(')
                {
                    result[k, 0] = 0;
                }
                else
                {
                    result[k, 0] = result[k - 1, 1];
                }
                for (int c = 1; c <= N; c++)
                {
                    if (symbols[k - 1] == '(')
                    {
                        result[k, c] = result[k - 1, c - 1];
                    }
                    else if (symbols[k - 1] == ')')
                    {
                        result[k, c] = result[k - 1, c + 1];
                    }
                    else
                    {
                        result[k, c] = result[k - 1, c - 1] + result[k - 1, c + 1];
                    }
                }
            }
            Console.WriteLine(result[N, 0]);
        }
    }
}
