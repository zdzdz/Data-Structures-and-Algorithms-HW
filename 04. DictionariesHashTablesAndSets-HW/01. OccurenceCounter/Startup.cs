// Write a program that counts in a given array of double values the number of 
//occurrences of each value. Use Dictionary<TKey,TValue>.

namespace OccurenceCounter
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            var input = new double[] { 3, 4, 4, -2.5, 3, 3, 4, 3, -2.5, 18, 5, 18 };
            //var input = new List<string> {"stop", "star", "go", "stop", "start"};

            var occurences = CountOccurences.GetOccurences(input);

            foreach (var keyValue in occurences)
            {
                Console.WriteLine("{0} --> {1} times", keyValue.Key, keyValue.Value);
            }
        }
    }
}
