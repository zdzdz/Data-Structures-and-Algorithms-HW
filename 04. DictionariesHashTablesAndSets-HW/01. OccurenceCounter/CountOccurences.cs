namespace OccurenceCounter
{
    using System.Collections.Generic;

    public class CountOccurences
    {
        public static Dictionary<T, int> GetOccurences<T>(ICollection<T> collection)
        {
            var valueOccureneces = new Dictionary<T, int>();

            foreach (var item in collection)
            {
                if (valueOccureneces.ContainsKey(item))
                {
                    valueOccureneces[item]++;
                }
                else
                {
                    valueOccureneces[item] = 1;
                }
            }

            return valueOccureneces;
        }
    }
}