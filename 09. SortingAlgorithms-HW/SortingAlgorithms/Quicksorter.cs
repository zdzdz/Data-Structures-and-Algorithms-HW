namespace SortingAlgorithms
{
    using System;
    using System.Collections.Generic;

    public class Quicksorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            this.Sort(collection, 0, collection.Count - 1);
        }

        private void Sort(IList<T> collection, int start, int end)
        {
            if (start <= end)
            {
                T pivot = collection[start];
                var positionOfLastBiggest = end;

                for (int i = end; i >= start; i--)
                {
                    if (collection[i].CompareTo(pivot) > 0)
                    {
                        this.Swap(positionOfLastBiggest, i, collection);
                        --positionOfLastBiggest;
                    }
                }

                this.Swap(positionOfLastBiggest, start, collection);

                this.Sort(collection, start, positionOfLastBiggest - 1);
                this.Sort(collection, positionOfLastBiggest + 1 , end);
            }
        }

        private void Swap(int start, int end, IList<T> collection)
        {
            var buffer = collection[start];
            collection[start] = collection[end];
            collection[end] = buffer;
        }
    }
}
