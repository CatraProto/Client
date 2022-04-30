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
using CatraProto.Client.MTProto.Session.Interfaces;
using CatraProto.TL;

namespace CatraProto.Client.MTProto.Session.Models
{
    internal class UpdatesStates : SessionModel
    {
        private readonly Dictionary<long, UpdatesState> _updatesStates = new Dictionary<long, UpdatesState>();
        private readonly UpdatesState _commonUpdatesState;


        public UpdatesStates(object mutex) : base(mutex)
        {
            _commonUpdatesState = new UpdatesState(mutex);
        }

        public UpdatesState GetState(long? channelId = null)
        {
            lock (Mutex)
            {
                if (channelId == null)
                {
                    return _commonUpdatesState;
                }
                else
                {
                    if (_updatesStates.TryGetValue(channelId.Value, out var state))
                    {
                        return state;
                    }

                    state = new UpdatesState(Mutex);
                    state.SetData(isActive: true);
                    _updatesStates.Add(channelId.Value, state);
                    return state;
                }
            }
        }

        public IList<(long chatId, UpdatesState state)> GetAllChannelsStates()
        {
            lock (Mutex)
            {
                var result = new List<(long chatId, UpdatesState state)>();
                foreach (var keyValuePair in _updatesStates)
                {
                    result.Add((keyValuePair.Key, keyValuePair.Value));
                }

                return result;
            }
        }

        public void Read(Reader reader)
        {
            lock (Mutex)
            {
                _commonUpdatesState.Read(reader);
                var count = reader.ReadInt32().Value;
                for (var i = 0; i < count; i++)
                {
                    var channelId = reader.ReadInt64().Value;
                    var updatesState = new UpdatesState(Mutex);
                    _updatesStates.Add(channelId, updatesState);
                    updatesState.Read(reader);
                }
            }
        }

        public void Save(Writer writer)
        {
            lock (Mutex)
            {
                _commonUpdatesState.Save(writer);
                writer.WriteInt32(_updatesStates.Count);
                foreach (var (channelId, updatesState) in _updatesStates)
                {
                    writer.WriteInt64(channelId);
                    updatesState.Save(writer);
                }
            }
        }
    }
}