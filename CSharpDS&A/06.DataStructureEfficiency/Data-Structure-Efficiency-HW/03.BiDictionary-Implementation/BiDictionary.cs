namespace BiDictionaryImplementation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Wintellect.PowerCollections;

    class BiDictionary<K1, K2, V>
    {
        private const bool DuplicatesAllowed = false;

        private MultiDictionary<K1, V> firstKeyValuePairs;
        private MultiDictionary<K2, V> secondKeyValuePairs;
        private MultiDictionary<KeyValuePair<K1, K2>, V> thirdKeyValuePairs;

        public BiDictionary()
        {
            this.firstKeyValuePairs = new MultiDictionary<K1, V>(DuplicatesAllowed);
            this.secondKeyValuePairs = new MultiDictionary<K2, V>(DuplicatesAllowed);
            this.thirdKeyValuePairs = new MultiDictionary<KeyValuePair<K1, K2>, V>(DuplicatesAllowed);
        }

        public IEnumerable<V> GetValuesByFirstKey(K1 key)
        {
            var output = this.firstKeyValuePairs[key];

            if (output.Count != 0)
            {
                return output;
            }

            throw new KeyNotFoundException();   
        }

        public IEnumerable<V> GetValuesBySecondKey(K2 key)
        {
            var output = this.secondKeyValuePairs[key];

            if (output.Count != 0)
            {
                return output;
            }

            throw new KeyNotFoundException();   
        }

        public IEnumerable<V> GetValuesByBothKeys(K1 key1, K2 key2)
        {
            var output = this.thirdKeyValuePairs[new KeyValuePair<K1, K2>(key1, key2)];

            if (output.Count != 0)
            {
                return output;
            }

            throw new KeyNotFoundException();   
        }

        public void Add(K1 key1, K2 key2, V value)
        {
            this.firstKeyValuePairs.Add(key1, value);
            this.secondKeyValuePairs.Add(key2, value);
            this.thirdKeyValuePairs.Add(new KeyValuePair<K1, K2>(key1, key2), value);
        }

        public void RemoveWithFirstKey(K1 key)
        {
            if (!this.firstKeyValuePairs.ContainsKey(key))
            {
                throw new KeyNotFoundException();    
            }

            this.firstKeyValuePairs.Remove(key);    
        }

        public void RemoveWithSecondKey(K2 key)
        {
            if (!this.secondKeyValuePairs.ContainsKey(key))
            {
                throw new KeyNotFoundException();    
            }

            this.secondKeyValuePairs.Remove(key);    
        }

        public void RemoveWithBothKeys(K1 key1, K2 key2)
        {
            if (!this.thirdKeyValuePairs.ContainsKey(new KeyValuePair<K1, K2>(key1, key2)))
            {
                throw new KeyNotFoundException();
            }

            this.thirdKeyValuePairs.Remove(new KeyValuePair<K1, K2>(key1, key2));
        }
    }
}
