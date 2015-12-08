namespace HashTable
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class CHashTable<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>
    {
        private const float ResizeCoeff = 0.75f;

        private LinkedList<KeyValuePair<TKey, TValue>>[] values;
        private int count;
        private int capacity;

        public CHashTable()
        {
            this.Clear();
        }

        public int Count
        {
            get
            {
                return this.count;
            }
        }

        public TKey[] Keys
        {
            get
            {
                var listOfKeys = new List<TKey>(this.count);

                foreach (var pair in this)
                {
                    listOfKeys.Add(pair.Key);
                }

                return listOfKeys.ToArray();
            }
        }

        public TValue this[TKey key]
        {
            get
            {
                TValue valueToReturn = this.FindValue(key);

                return valueToReturn;
            }
        }

        public void Clear()
        {
            this.count = 0;
            this.capacity = 16;
            this.values = new LinkedList<KeyValuePair<TKey, TValue>>[16];
        }

        public void Add(TKey key, TValue value)
        {
            if (this.Contains(key))
            {
                return;
            }

            var index = this.GetIndex(key);

            if (this.values[index] == null)
            {
                this.values[index] = new LinkedList<KeyValuePair<TKey, TValue>>();
            }

            this.values[index].AddFirst(new KeyValuePair<TKey, TValue>(key, value));
            ++this.count;

            if (this.count > ResizeCoeff * this.capacity)
            {
                this.ResizeAndRewritte();
            }
        }

        public TValue FindValue(TKey key)
        {
            var index = this.GetIndex(key);

            if (this.values[index] == null)
            {
                return default(TValue);
            }

            var chain = this.values[index];

            foreach (var pair in chain)
            {
                if (pair.Key.Equals(key))
                {
                    return pair.Value;
                }
            }

            return default(TValue);
        }

        public bool Contains(TKey key)
        {
            var index = this.GetIndex(key);

            if (this.values[index] == null)
            {
                return false;
            }

            var chain = this.values[index];

            foreach (var pair in chain)
            {
                if (pair.Key.Equals(key))
                {
                    return true;
                }
            }

            return false;
        }

        public void Remove(TKey key)
        {
            if (!this.Contains(key))
            {
                throw new InvalidOperationException("can not find key");
            }

            var index = this.GetIndex(key);

            var valueToRemove = this.values[index].First(item => item.Key.ToString() == key.ToString());
            this.values[index].Remove(valueToRemove);
            --this.count;

            if (this.values[index].Count == 0)
            {
                this.values[index] = null;
            }
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            foreach (var valuesList in this.values)
            {
                if (valuesList == null)
                {
                    continue;
                }

                foreach (var item in valuesList)
                {
                    yield return item;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private int GetIndex(TKey key)
        {
            var hash = key.GetHashCode();

            if (hash < 0)
            {
                hash *= -1;
            }

            var index = hash % this.values.Length;

            return index;
        }

        private void ResizeAndRewritte()
        {
            var oldvalues = (LinkedList<KeyValuePair<TKey, TValue>>[])this.values.Clone();
            this.capacity *= 2;
            this.values = new LinkedList<KeyValuePair<TKey, TValue>>[this.capacity];
            this.count = 0;

            foreach (var item in oldvalues)
            {
                if (item != null)
                {
                    foreach (var value in item)
                    {
                        this.Add(value.Key, value.Value);
                    }
                }
            }
        }
    }
}
