namespace SortingAlgorithms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class MergeSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            this.MergeSort(collection, 0, collection.Count - 1);
        }

        private void MergeSort(IList<T> collection, int start, int end)
        {
            if (start < end)
            {
                var middle = (start + end)/2;
                this.MergeSort(collection, start, middle);
                this.MergeSort(collection, middle + 1, end);

                // merging
                var currentPosition = start;
                var secondCollectionPosition = middle + 1;
                while (currentPosition <= middle)
                {
                    if (collection[currentPosition].CompareTo(collection[secondCollectionPosition]) > 0)
                    {
                        this.Swap(currentPosition, secondCollectionPosition, collection);

                        // keep second part sorted
                        while (secondCollectionPosition < end && 
                            collection[secondCollectionPosition].CompareTo(collection[secondCollectionPosition + 1]) > 0)
                        {
                            this.Swap(secondCollectionPosition, secondCollectionPosition + 1, collection);
                            ++secondCollectionPosition;
                        }

                        secondCollectionPosition = middle + 1;
                    }

                    ++currentPosition;
                }

                while (currentPosition < end && 
                    collection[currentPosition].CompareTo(collection[currentPosition + 1]) > 0)
                {
                    this.Swap(currentPosition, currentPosition + 1, collection);
                    ++currentPosition;
                }
            }
        }

        private void Swap(int start, int end, IList<T> collection)
        {
            var buff = collection[start];
            collection[start] = collection[end];
            collection[end] = buff;
        }
    }
}
