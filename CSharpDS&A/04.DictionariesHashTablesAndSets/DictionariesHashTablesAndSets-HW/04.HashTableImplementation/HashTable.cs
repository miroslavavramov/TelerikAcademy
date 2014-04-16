namespace HashTableImplementation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class HashTable<K, V> : IEnumerable<KeyValuePair<K, V>>
    {
        private const int InitialCapacity = 16;
        private const double MaxLoad = 0.75D;

        private int count;
        private LinkedList<KeyValuePair<K, V>>[] buckets;

        public HashTable(int size = InitialCapacity)
        {
            this.buckets = new LinkedList<KeyValuePair<K, V>>[size];
            this.count = 0;
        }

        public int Size
        {
            get
            {
                return this.buckets.Length;
            }
        }

        public int Count
        {
            get
            {
                return this.count;
            }
        }

        public IEnumerable<K> Keys
        {
            get
            {
                var keys = new List<K>();

                foreach (var bucket in this.buckets)
                {
                    if (bucket != null)
                    {
                        keys.AddRange(bucket.Select(x => x.Key));
                    }   
                }
                return keys.ToArray();
            }
        }

        public V this[K key]
        {
            get
            {
                V value;

                if (TryGetValue(key, out value))
                {
                    return value;
                }

                throw new KeyNotFoundException("There is no element with the specified key");
            }
            set
            {
                int bucketHash = GetBucketHash(key);

                if (this.buckets[bucketHash] != null)
                {
                    var pairToRemove = this.buckets[bucketHash].Where(kvp => kvp.Key.Equals(key)).First();

                    if (!pairToRemove.Equals(null))
                    {
                        this.buckets[bucketHash].Remove(pairToRemove);
                        this.buckets[bucketHash].AddLast(new KeyValuePair<K, V>(key, value));
                        return;
                    }
                }

                throw new KeyNotFoundException("There is no element with the specified key");
            }
        }

        public void Add(K key, V value)
        {
            int bucketHash = GetBucketHash(key);
            
            if (this.buckets[bucketHash] == null)
            {
                this.buckets[bucketHash] = new LinkedList<KeyValuePair<K, V>>();
            }

            if (this.ContainsKey(key))
            {
                throw new ArgumentException("Hash Table can't contain duplicate keys.");
            }
            
            else
            {
                var pair = new KeyValuePair<K, V>(key, value);

                this.buckets[bucketHash].AddLast(pair);
                this.count++;

                if (this.Count / this.Size >= MaxLoad)
                {
                    Resize();
                }
            }
        }

        public void Remove(K key)
        {
            int bucketHash = GetBucketHash(key);

            if (this.buckets[bucketHash] != null)
            {
                var pairToRemove = this.buckets[bucketHash].Where(kvp => kvp.Key.Equals(key)).First();

                if (!pairToRemove.Equals(null))
                {
                    this.buckets[bucketHash].Remove(pairToRemove);
                    this.count--;
                }
            }
        }

        public void Clear()
        {
            this.buckets = new LinkedList<KeyValuePair<K,V>>[InitialCapacity];
            this.count = 0;
        }

        public V Find(K key)
        {
            return this[key];
        }

        public bool TryGetValue(K key, out V value)
        {
            value = default(V);
            int bucketHash = GetBucketHash(key);

            foreach (var pair in this.buckets[bucketHash])
            {
                if (pair.Key.Equals(key))
                {
                    value = pair.Value;
                    return true;
                }
            }
            return false;
        }

        public bool ContainsKey(K key)
        {
            int bucketHash = GetBucketHash(key);

            if (this.buckets[bucketHash] != null)
            {
                foreach (var pair in this.buckets[bucketHash])
                {
                    if (pair.Key.Equals(key))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private int GetBucketHash(K key)
        {
            if (key == null)
            {
                throw new ArgumentNullException("Key can't be null.");
            }

            int bucketHash = key.GetHashCode() % this.Size;
            
            if(bucketHash < 0)
            {
                bucketHash = -bucketHash;
            }

            return bucketHash;
        }

        private void Resize()
        {
            var newBuckets = new LinkedList<KeyValuePair<K,V>>[this.Size * 2 - 1];  
            
            foreach (var bucket in this.buckets)
            {
                if (bucket != null)
                {
                    foreach (var pair in bucket)
                    {
                        int newBucketHash = GetBucketHash(pair.Key);

                        if (newBuckets[newBucketHash] == null)
                        {
                            newBuckets[newBucketHash] = new LinkedList<KeyValuePair<K, V>>();
                        }

                        newBuckets[newBucketHash].AddLast(pair);
                    }
                }
            }

            this.buckets = newBuckets;
        }

        public IEnumerator<KeyValuePair<K, V>> GetEnumerator()
        {
            foreach (var bucket in this.buckets)
            {
                if (bucket != null)
                {
                    foreach (var pair in bucket)
                    {
                        yield return pair;
                    }
                }
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
