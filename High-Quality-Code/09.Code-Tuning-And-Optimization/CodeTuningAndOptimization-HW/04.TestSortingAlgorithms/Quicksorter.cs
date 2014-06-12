namespace TestSortingAlgorithms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Quicksorter<T> 
        where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            this.QuickSort(collection, 0, collection.Count - 1);
        }

        private void QuickSort(IList<T> collection, int start, int end)
        {
            if (start < end)
            {
                int pIndex = this.Partition(collection, start, end);
                this.QuickSort(collection, start, pIndex - 1);
                this.QuickSort(collection, pIndex + 1, end);
            }
        }

        private int Partition(IList<T> collection, int start, int end)
        {
            int pivotIndex = start;
            T pivot = collection[end];
            T temp = default(T);

            for (int i = start; i < end; i++)
            {
                if (collection[i].CompareTo(pivot) < 0)
                {
                    temp = collection[i];
                    collection[i] = collection[pivotIndex];
                    collection[pivotIndex] = temp;
                    pivotIndex++;
                }
            }

            collection[end] = collection[pivotIndex];
            collection[pivotIndex] = pivot;
            return pivotIndex; 
        }
    }
}
