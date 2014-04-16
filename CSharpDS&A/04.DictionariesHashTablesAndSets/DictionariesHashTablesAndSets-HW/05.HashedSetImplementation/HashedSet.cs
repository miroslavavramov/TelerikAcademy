namespace HashedSetImplementation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using HashTableImplementation;

    public class HashedSet<T> : IEnumerable<T>
    {
        private HashTable<T, int> elements;

        public HashedSet()
            :this(null)
        {
        }

        public HashedSet(IEnumerable<T> collection)
        {
            this.elements = new HashTable<T, int>();

            if (collection != null)
            {
                this.AddRange(collection);
            }
        }

        public int Count
        {
            get
            {
                return this.elements.Count;
            }
        }

        public void Add(T item)
        {
            this.elements.Add(item, 0);
        }

        public void AddRange(IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                this.Add(item);
            }
        }

        public bool Find(T item)
        {
            return this.elements.ContainsKey(item);
        }

        public void Remove(T item)
        {
            this.elements.Remove(item);
        }

        public void Clear()
        {
            this.elements.Clear();
        }

        public void UnionWith(HashedSet<T> secondSet)
        {
            foreach (var item in secondSet)
            {
                if (!this.elements.ContainsKey(item))
                {
                    this.Add(item);
                }
            }
        }
        
        public void IntersectWith(HashedSet<T> secondSet)
        {
            foreach (var item in this)
            {
                if(!secondSet.Contains(item))
                {
                    this.Remove(item);
                }
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var key in this.elements.Keys)
            {
                yield return key;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
