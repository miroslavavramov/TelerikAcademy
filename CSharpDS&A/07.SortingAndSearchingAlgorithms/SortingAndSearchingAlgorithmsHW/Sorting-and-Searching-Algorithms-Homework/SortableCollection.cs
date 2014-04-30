namespace SortingHomework
{
    using System;
    using System.Collections.Generic;

    public class SortableCollection<T> where T : IComparable<T>
    {
        private readonly IList<T> items;

        public SortableCollection()
        {
            this.items = new List<T>();
        }

        public SortableCollection(IEnumerable<T> items)
        {
            this.items = new List<T>(items);
        }

        public IList<T> Items
        {
            get
            {
                return this.items;
            }
        }

        public void Sort(ISorter<T> sorter)
        {
            sorter.Sort(this.items);
        }

        public bool LinearSearch(T item)
        {
            foreach (var elem in this.Items)
            {
                if (item.CompareTo(elem) == 0)
                {
                    return true;
                }
            }

            return false;
        }

        public bool BinarySearch(T item)
        {
            int start = 0;
            int end = this.Items.Count;
            int mid;

            while (start + 1 < end)
            {
                mid = (start + end) / 2;

                if (item.CompareTo(this.Items[mid]) < 0)
                {
                    end = mid - 1;
                }
                else if (item.CompareTo(this.Items[mid]) > 0)
                {
                    start = mid + 1;
                }
                else
                {
                    return true;
                }
            }

            return false;
        }

        public void Shuffle()
        {
            var randGen = new Random();
            int pos;

            for (int i = 0; i < this.Items.Count; i++)
            {
                pos = randGen.Next(0, this.Items.Count - i);

                var buffer = this.Items[i];
                this.Items[i] = this.Items[pos];
                this.Items[pos] = buffer;
            }
        }

        public void PrintAllItemsOnConsole()
        {
            for (int i = 0; i < this.items.Count; i++)
            {
                if (i == 0)
                {
                    Console.Write(this.items[i]);
                }
                else
                {
                    Console.Write(" " + this.items[i]);
                }
            }

            Console.WriteLine();
        }
    }
}
