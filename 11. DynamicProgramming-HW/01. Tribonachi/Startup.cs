namespace Tribonachi
{
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            var numbers = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();

            long t1 = numbers[0];
            long t2 = numbers[1];
            long t3 = numbers[2];
            var n = numbers[3];
            long result = 0;

            if (n == 3)
            {
                result = t3;
            }
            else
            {
                for (int i = 4; i <= n; i++)
                {
                    result = t1 + t2 + t3;
                    t1 = t2;
                    t2 = t3;
                    t3 = result;
                }
            }

            Console.WriteLine(result);
        }
    }
}
