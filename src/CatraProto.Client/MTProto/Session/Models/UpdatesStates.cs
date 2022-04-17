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