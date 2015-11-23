namespace SortingAlgorithms
{

    using System;
    using System.Collections.Generic;

    public class SelectionSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            for (int i = 0; i < collection.Count; i++)
            {
                T bestElement = collection[i];
                var minElementposition = i;

                for (int j = i + 1; j < collection.Count; j++)
                {
                    if (collection[j].CompareTo(bestElement) < 0)
                    {
                        bestElement = collection[j];
                        minElementposition = j;
                    }
                }

                collection[minElementposition] = collection[i];
                collection[i] = bestElement;
            }
        }
    }
}
