namespace SuperSum
{
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            var numbers = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();

            var k = numbers[0];
            var n = numbers[1];
            var result = SuperSum(k, n);

            Console.WriteLine(result);
        }

        private static int SuperSum(int k, int n)
        {
            int result = 0;
            if (k == 0)
            {
                return n;
            }
            for (int i = 1; i <= n; i++)
            {
                result += SuperSum(k - 1, i);
            }
            return result;
        }
    }
}
