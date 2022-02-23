using System.Collections.Generic;
using CatraProto.Client.MTProto.Session.Interfaces;
using CatraProto.TL;

namespace CatraProto.Client.MTProto.Session.Models
{
    class UpdatesStates : SessionModel
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
                List<(long chatId, UpdatesState state)> result = new List<(long chatId, UpdatesState state)>();
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
                var count = reader.Read<int>();
                for (var i = 0; i < count; i++)
                {
                    var channelId = reader.Read<long>();
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