using GenericLab;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace GenericLab
{
    public class MultiDictionary<K, V> : IMultiDictionary<K, V>, IEnumerable<KeyValuePair<K, IEnumerable<V>>>
    {
        Dictionary<K, LinkedList<V>> dictionary = new Dictionary<K, LinkedList<V>>();
        

        public int Count => dictionary.SelectMany(d => d.Value).Count();
        public ICollection<K> Keys => dictionary.Keys;
        public ICollection<V> Values => dictionary.SelectMany(d => d.Value).ToList();


        public void Add(K key, V value)
        {
            if (!dictionary.ContainsKey(key))
            {
                dictionary.Add(key, new LinkedList<V>());
            }

            dictionary[key].AddLast(value);

        }

        public void Clear() => dictionary.Clear();

        public bool Contains(K key, V value) => dictionary.ContainsKey(key) && dictionary[key].Contains(value);

        public bool ContainsKey(K key) => dictionary.ContainsKey(key);

        public IEnumerator<KeyValuePair<K, IEnumerable<V>>> GetEnumerator() =>
            dictionary.Select(p => new KeyValuePair<K, IEnumerable<V>>(p.Key, p.Value)).GetEnumerator();

        public bool Remove(K key) => dictionary.Remove(key);

        public bool Remove(K key, V value) => dictionary[key].Remove(value);

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
