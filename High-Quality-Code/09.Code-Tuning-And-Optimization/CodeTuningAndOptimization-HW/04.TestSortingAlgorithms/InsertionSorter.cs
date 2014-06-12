namespace TestSortingAlgorithms
{
    using System;
    using System.Collections.Generic;

    public class InsertionSorter<T> 
        where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            this.InsertionSort(collection, 0, collection.Count - 1);
        }

        private void InsertionSort(IList<T> collection, int start, int end)
        {
            T currentElement;
            int index;

            for (int i = 0; i <= end; i++)
            {
                currentElement = collection[i];
                index = i - 1;

                while (index >= 0 && currentElement.CompareTo(collection[index]) < 0)
                {
                    collection[index + 1] = collection[index];
                    index--;
                }

                collection[index + 1] = currentElement;
            }
        }
    }
}
