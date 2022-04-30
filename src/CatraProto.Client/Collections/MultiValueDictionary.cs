/*
CatraProto, a C# library that implements the MTProto protocol and the Telegram API.
Copyright (C) 2022 Aquatica <aquathing@protonmail.com>

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Lesser General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Lesser General Public License for more details.

You should have received a copy of the GNU Lesser General Public License
along with this program.  If not, see <https://www.gnu.org/licenses/>.
*/

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