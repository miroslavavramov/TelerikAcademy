namespace PriorityQueueImplementatiton
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    class PriorityQueue<T> : IEnumerable<T>
        where T : IComparable
    {
        private BinaryHeap<T> elements;

        public PriorityQueue()
            :this(null)
        {

        }

        public PriorityQueue(params T[] initialElements)
        {
            this.elements = new BinaryHeap<T>(initialElements);
        }

        public int Count
        {
            get
            {
                return this.elements.Count;
            }
        }

        public void Enqueue(T element)
        {
            this.elements.Add(element);
        }

        public T Dequeue()
        {
            return this.elements.Pop();
        }

        public T Peek()
        {
            return this.elements.Peek();
        }

        public void Clear()
        {
            this.elements.Clear();
        }

        public IEnumerator<T> GetEnumerator()
        {
            //return this.elements.GetEnumerator();
            var enumerated = new BinaryHeap<T>();

            foreach (var item in this.elements)
            {
                enumerated.Add(item);
            }

            while (enumerated.Count > 0)
            {
                yield return enumerated.Pop();
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();   
        }

        public override string ToString()
        {
            return string.Join(", ", this);
        }
    }
}
