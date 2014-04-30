namespace SortingHomework
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
            this.MergeSort(collection);
        }

        private void MergeSort(IList<T> collection)
        {
            if (collection.Count > 1)
            {
                int mid = collection.Count / 2;

                var left = collection.Take(mid).ToList();
                var right = collection.Skip(mid).ToList();

                this.MergeSort(left);
                this.MergeSort(right);

                var result = this.Merge(left, right);

                for (int i = 0; i < collection.Count; i++)
                {
                    collection[i] = result[i];
                }
            }
        }

        private IList<T> Merge(IList<T> left, IList<T> right)
        {
            int leftIndex = 0;
            int rightIndex = 0;
            var result = new List<T>();

            while (leftIndex < left.Count || rightIndex < right.Count)
            {
                if (leftIndex < left.Count && rightIndex < right.Count)
                {
                    if (left[leftIndex].CompareTo(right[rightIndex]) < 0)
                    {
                        result.Add(left[leftIndex]);
                        leftIndex++;
                    }
                    else
                    {
                        result.Add(right[rightIndex]);
                        rightIndex++;
                    }
                }
                else if (leftIndex < left.Count)
                {
                    result.Add(left[leftIndex]);
                    leftIndex++;
                }
                else if (rightIndex < right.Count)
                {
                    result.Add(right[rightIndex]);
                    rightIndex++;
                }
            }

            return result;  
        }
    }
}
