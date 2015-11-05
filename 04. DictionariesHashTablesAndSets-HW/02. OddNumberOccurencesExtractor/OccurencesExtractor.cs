using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using OccurenceCounter;

namespace OddNumberOccurencesExtractor
{
    public class OccurencesExtractor
    {
        public static ICollection<T> Apply<T>(ICollection<T> input)
        {
            var result = new List<T>();
            var uniqueOccurrences = CountOccurences.GetOccurences(input);

            foreach (var item in uniqueOccurrences)
            {
                if (item.Value % 2 != 0)
                {
                    result.Add(item.Key);
                }
            }

            return result;
        }
    }
}
