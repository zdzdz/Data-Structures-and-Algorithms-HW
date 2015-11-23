using System;
using System.IO;

namespace ColorfulBunnies
{
    public class Program
    {
        public static void Main()
        {
            int numberOfRabits = int.Parse(Console.ReadLine());
            var responses = new int[numberOfRabits];

            for (int i = 0; i < numberOfRabits; i++)
            {
                responses[i] = int.Parse(Console.ReadLine());
            }

            var result = GetMinimum(responses);
            Console.WriteLine(result);
        }

        public static int GetMinimum(int[] responses)
        {
            int[] cache = new int[1000002];
            for (int i = 0; i < responses.Length; i++)
            {
                cache[responses[i] + 1]++;
            }

            int minCount = 0;
            for (int i = 0; i < cache.Length; i++)
            {
                if (cache[i] == 0)
                {
                    continue;
                }
                if (cache[i] <= i)
                {
                    minCount += i;
                }
                else
                {
                    minCount += (int) Math.Ceiling((double) cache[i]/i)*i;
                }
            }

            return minCount;
        }
    }
}
