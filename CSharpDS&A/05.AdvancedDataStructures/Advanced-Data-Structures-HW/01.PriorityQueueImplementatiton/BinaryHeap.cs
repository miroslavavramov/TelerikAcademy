namespace PriorityQueueImplementatiton
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    class BinaryHeap<T> : IEnumerable<T>
        where T : IComparable
    {
        private IList<T> heap;

        public BinaryHeap()
            : this(null)
        {
        }

        public BinaryHeap(params T[] initialElements)
        {
            this.heap = new List<T>();

            if (initialElements != null)
            {
                foreach (var element in initialElements)
                {
                    this.Add(element);
                }
            }
        }

        public int Count
        {
            get
            {
                return this.heap.Count;
            }
        }

        public void Add(T element)
        {
            this.heap.Add(element);

            this.RebalanceUpwards(this.Count - 1);
        }

        public T Peek()
        {
            if (this.Count < 1)
            {
                throw new InvalidOperationException("Can't retreive elements from and empty heap.");
            }

            return this.heap[0];
        }

        public T Pop()
        {
            var max = this.Peek();

            this.RemoveAt(0);

            return max;
        }

        public void RemoveAt(int index)
        {
            int lastLeafIndex = this.Count - 1;

            this.heap[index] = this.heap[lastLeafIndex];

            this.heap.RemoveAt(lastLeafIndex);
            this.RebalanceDownwards(index);

        }

        public void Clear()
        {
            this.heap.Clear();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this.heap.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public override string ToString()
        {
            var output = new StringBuilder();

            for (int i = 0; i < this.Count; i++)
            {
                output.AppendFormat("[{0}] = {1} {2}", i, this.heap[i], Environment.NewLine);
            }

            return output.ToString();
        }

        private int GetParentIndex(int index)
        {
            return (index - 1) / 2;
        }

        private int GetLeftChildIndex(int index)
        {
            return (index * 2) + 1;
        }

        private int GetRightChildIndex(int index)
        {
            return (index * 2) + 2;
        }

        private void Swap(int childIndex, int parentIndex)
        {
            T buffer = this.heap[parentIndex];

            this.heap[parentIndex] = this.heap[childIndex];
            this.heap[childIndex] = buffer;
        }

        private void RebalanceUpwards(int index)
        {
            int parentIndex = this.GetParentIndex(index);

            while (index > 0 && this.heap[index].CompareTo(this.heap[parentIndex]) > 0)
            {
                this.Swap(index, parentIndex);

                index = parentIndex;
                parentIndex = this.GetParentIndex(index);
            }
        }

        private void RebalanceDownwards(int index)
        {
            int leftChildIndex = this.GetLeftChildIndex(index);
            int rightChildIndex = this.GetRightChildIndex(index);

            int maxElementIndex = index;

            if (leftChildIndex < this.Count 
                && this.heap[leftChildIndex].CompareTo(this.heap[maxElementIndex]) > 0)
            {
                maxElementIndex = leftChildIndex;
            }

            if (rightChildIndex < this.Count 
                && this.heap[rightChildIndex].CompareTo(this.heap[maxElementIndex]) > 0)
            {
                maxElementIndex = rightChildIndex;
            }

            if (index != maxElementIndex)
            {
                this.Swap(maxElementIndex, index);

                this.RebalanceDownwards(maxElementIndex);
            }
        }
    }
}
