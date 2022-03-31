using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace CatraProto.Client.Collections
{
    public class MultiValueDictionary<TKey, TValue> : IEnumerable<KeyValuePair<TKey, List<TValue>>> where TKey : notnull 
    {
        private readonly Dictionary<TKey, List<TValue>> _backingDictionary = new Dictionary<TKey, List<TValue>>();
        public int Count
        {
            get => _backingDictionary.Count;
        }
        
        public bool TryGetValue(TKey key, [MaybeNullWhen(false)] out List<TValue> value)
        {
            if (_backingDictionary.TryGetValue(key, out var list))
            {
                value = list;
                return true;
            }

            value = null;
            return false;
        }

        public bool TryInsertUnique(TKey key, TValue value)
        {
            if (_backingDictionary.TryGetValue(key, out var list))
            {
                if (list.Contains(value))
                {
                    return false;
                }
                
                list.Add(value);
                return true;
            }
            else
            {
                var newList = new List<TValue> { value };
                _backingDictionary.TryAdd(key, newList);
                return true;
            }
        }
        
        public void Insert(TKey key, TValue value)
        {
            if (_backingDictionary.TryGetValue(key, out var list))
            {
                list.Add(value);
            }
            else
            {
                var newList = new List<TValue> { value };
                _backingDictionary.TryAdd(key, newList);
            }
        }

        public bool TryRemove(TKey key, TValue value)
        {
            if (!_backingDictionary.TryGetValue(key, out var list))
            {
                return false;
            }

            list.Remove(value);
            return true;
        }

        public bool TryRemoveAll(TKey key, [MaybeNullWhen(false)] out List<TValue> value)
        {
            return _backingDictionary.Remove(key, out value);
        }


        public IEnumerator<KeyValuePair<TKey, List<TValue>>> GetEnumerator()
        {
            return _backingDictionary.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)_backingDictionary).GetEnumerator();
        }
    }
}