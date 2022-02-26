using CatraProto.Client.Crypto;
using CatraProto.Client.MTProto.Session.Interfaces;
using CatraProto.TL;

namespace CatraProto.Client.MTProto.Session.Models
{
    class RandomId : SessionModel
    {
        private readonly object _mutex;
        private long _lastId = CryptoTools.CreateRandomInt();

        public RandomId(object mutex) : base(mutex)
        {
            _mutex = mutex;
        }

        public long GetNextId()
        {
            lock (_mutex)
            {
                return ++_lastId;
            }
        }

        public void Read(Reader reader)
        {
            lock (_mutex)
            {
                _lastId += reader.Read<long>();
            }
        }

        public void Save(Writer writer)
        {
            lock (_mutex)
            {
                writer.Write(_lastId);
            }
        }
    }
}