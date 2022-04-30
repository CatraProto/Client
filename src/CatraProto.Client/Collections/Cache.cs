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

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace CatraProto.Client.Collections
{
    public class Cache<TKey, TValue> where TKey : notnull
    {
        private readonly Dictionary<TKey, (TValue Item, uint Count)> _backingDictionary = new Dictionary<TKey, (TValue Item, uint Count)>();
        private readonly uint _maxSize;
        public Cache(uint maxSize)
        {
            if (maxSize == 0)
            {
                maxSize = 1;
            }

            _maxSize = maxSize;
        }

        public void CacheItem(TKey key, TValue value, out (TKey key, TValue value)? removedItem)
        {
            removedItem = null;
            if (_maxSize == 0)
            {
                return;
            }

            if (_backingDictionary.Remove(key, out var item))
            {
                _backingDictionary.Add(key, (value, item.Count));
                return;
            }

            if (_backingDictionary.Count + 1 > _maxSize)
            {
                var oldestKey = ScanForOldest();
                _backingDictionary.Remove(oldestKey, out var outItem);
                removedItem = (oldestKey, outItem.Item);
            }

            _backingDictionary.Add(key, (value, 1));
        }

        public bool TryGetValue(TKey key, [MaybeNullWhen(false)] out TValue item)
        {
            if (_backingDictionary.Remove(key, out var tryItem))
            {
                item = tryItem.Item;
                _backingDictionary.Add(key, (item, IncrementChecked(tryItem.Count, 1)));
                return true;
            }

            item = default;
            return false;
        }

        public bool InvalidateItem(TKey key, [MaybeNullWhen(false)] out TValue item)
        {
            if (_backingDictionary.Remove(key, out var tryItem))
            {
                item = tryItem.Item;
                return true;
            }

            item = default;
            return false;
        }

        private TKey ScanForOldest()
        {
            if (_backingDictionary.Count == 0)
            {
                throw new InvalidOperationException("Count must not be 0");
            }

            TKey? oldestKey = default;
            uint? tinierCount = null;
            foreach (var (key, (item, count)) in _backingDictionary)
            {
                if (tinierCount == null || tinierCount > count)
                {
                    tinierCount = count;
                    oldestKey = key;
                }
            }

            return oldestKey!;
        }

        private uint IncrementChecked(uint value, int add)
        {
            var r = value + (uint)add;
            if (r < value)
            {
                return value;
            }

            return r;
        }
    }
}
