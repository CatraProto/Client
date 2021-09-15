using CatraProto.Client.MTProto.Session.Interfaces;
using CatraProto.TL;

namespace CatraProto.Client.MTProto.Session.Models
{
    class AuthKeyData
    {
        private byte[]? _authKey;
        private long? _firstSalt;
        private long? _authKeyId;
        private readonly object _mutex;

        public AuthKeyData(object mutex)
        {
            _mutex = mutex;
        }

        public void SetData(byte[] authKey, long authKeyId, long firstServerSalt)
        {
            lock (_mutex)
            {
                _authKey = authKey;
                _authKeyId = authKeyId;
                _firstSalt = firstServerSalt;
            }
        }

        public (byte[] key, long keyId, long salt)? GetData()
        {
            lock (_mutex)
            {
                if (_authKeyId == null)
                {
                    return null;
                }

                return (_authKey!, _authKeyId!.Value, _firstSalt!.Value);
            }
        }

        public void Read(Reader reader)
        {
            lock (_mutex)
            {
                _authKey = reader.Read<byte[]>();
                _authKeyId = reader.Read<long>();
                _firstSalt = reader.Read<long>();
            }
        }

        public void Save(Writer writer)
        {
            lock (_mutex)
            {
                if (_authKeyId != null)
                {
                    writer.Write(_authKey);
                    writer.Write(_authKeyId);
                    writer.Write(_firstSalt);
                }
            }
        }
    }
}