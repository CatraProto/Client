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

using System.Collections.Generic;
using System.Linq;

namespace CatraProto.Client.Connections.MessageScheduling
{
    public enum MessageValidity
    {
        Valid,
        Duplicate,
        TooOld
    }

    internal class MessageDuplicateChecker
    {
        private const int MaxCapacity = 1000;
        private readonly HashSet<long> _hashSet = new HashSet<long>();
        private long _currentMax;
        private long _currentMin;
        private long _nextMin;

        public MessageValidity IsValid(long messageId)
        {
            if (_currentMin == 0)
            {
                _currentMin = messageId;
                _nextMin = messageId;
            }

            if (messageId > _currentMin && (messageId < _nextMin))
            {
                _nextMin = messageId;
            }

            if (_currentMin == _nextMin && _hashSet.Count > 1)
            {
                _nextMin = _hashSet.Where(x => x != _currentMin).Min();
            }

            if (messageId > _currentMin && messageId < _currentMax)
            {
                if (_hashSet.Add(messageId))
                {
                    if (_hashSet.Count > MaxCapacity)
                    {
                        _hashSet.Remove(_currentMin);
                        _currentMin = _nextMin;
                    }
                    return MessageValidity.Valid;
                }
                else
                {
                    return MessageValidity.Duplicate;
                }
            }

            if (messageId < _currentMin)
            {
                if (_hashSet.Count == MaxCapacity)
                {
                    return MessageValidity.TooOld;
                }
                else
                {
                    _nextMin = _currentMin;
                    _currentMin = messageId;
                    _hashSet.Add(messageId);
                    return MessageValidity.Valid;
                }
            }

            if (messageId > _currentMax)
            {
                _currentMax = messageId;
                if (_hashSet.Count + 1 > MaxCapacity)
                {
                    _hashSet.Remove(_currentMin);
                    _currentMin = _nextMin;
                }

                _hashSet.Add(messageId);
                return MessageValidity.Valid;

            }

            return MessageValidity.Duplicate;
        }

        public void Clear()
        {
            _hashSet.Clear();
        }
    }
}
