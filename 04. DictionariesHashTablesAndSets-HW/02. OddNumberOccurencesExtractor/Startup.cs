//Write a program that extracts from a given sequence of strings all elements that present in it odd number of times. Example:

//{C#, SQL, PHP, PHP, SQL, SQL } -> {C#, SQL}

using System;

namespace OddNumberOccurencesExtractor
{
    public class Startup
    {
        public static void Main()
        {
            var input = new string[] { "C#", "SQL", "PHP", "PHP", "SQL", "SQL" };

            var oddOccurences = OccurencesExtractor.Apply(input);
            var count = oddOccurences.Count;

            Console.Write("{");
            foreach (var value in oddOccurences)
            {
                if (count > 1)
                {
                    Console.Write(value + ", ");
                }
                else
                {
                    Console.Write(value);
                }
                count--;
            }
            Console.WriteLine("}");
        }
    }
}
