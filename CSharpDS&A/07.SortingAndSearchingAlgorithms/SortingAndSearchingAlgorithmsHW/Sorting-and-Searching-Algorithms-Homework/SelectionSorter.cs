namespace SortingHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class SelectionSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            int length = collection.Count;

            for (int i = 0; i < length-1; i++)
            {
                int minIndex = i;

                for (int k = i + 1; k < length; k++)
                {
                    if (collection[k].CompareTo(collection[minIndex]) < 0)
                    {
                        minIndex = k;
                    }
                }

                if (minIndex != i)
                {
                    T buffer = collection[i];
                    collection[i] = collection[minIndex];
                    collection[minIndex] = buffer;
                }
            }
        }
    }
}
