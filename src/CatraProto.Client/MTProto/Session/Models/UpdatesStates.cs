using System.Collections.Generic;
using CatraProto.Client.MTProto.Session.Interfaces;
using CatraProto.TL;

namespace CatraProto.Client.MTProto.Session.Models
{
    class UpdatesStates
    {
        private readonly Dictionary<int, UpdatesState> _updatesStates = new Dictionary<int, UpdatesState>();
        private readonly UpdatesState _commonUpdatesState;
        private readonly object _mutex;

        public UpdatesStates(object mutex)
        {
            _commonUpdatesState = new UpdatesState(mutex);
            _mutex = mutex;
        }

        public UpdatesState GetState(int? channelId = null)
        {
            lock (_mutex)
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

                    state = new UpdatesState(_mutex);
                    _updatesStates.Add(channelId.Value, state);
                    return state;
                }
            }
        }

        public void Read(Reader reader)
        {
            lock (_mutex)
            {
                _commonUpdatesState.Read(reader);
                var count = reader.Read<int>();
                for (var i = 0; i < count; i++)
                {
                    var channelId = reader.Read<int>();
                    var updatesState = new UpdatesState(_mutex);
                    _updatesStates.Add(channelId, updatesState);
                    updatesState.Read(reader);
                }
            }
        }

        public void Save(Writer writer)
        {
            lock (_mutex)
            {
                _commonUpdatesState.Save(writer);
                writer.Write(_updatesStates.Count);
                foreach (var (channelId, updatesState) in _updatesStates)
                {
                    writer.Write(channelId);
                    updatesState.Save(writer);
                }
            }
        }
    }
}