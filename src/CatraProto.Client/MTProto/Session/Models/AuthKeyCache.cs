using CatraProto.Client.MTProto.Session.Interfaces;
using CatraProto.TL;

namespace CatraProto.Client.MTProto.Session.Models
{
    class AuthKeyCache : SessionModel
    {
        private byte[]? _authKey;
        private long? _firstSalt;
        private long? _authKeyId;
        private int? _expirationDate;
        private bool? _isBound;

        public AuthKeyCache(object mutex) : base(mutex)
        {
        }

        public void SetData(byte[] authKey, long authKeyId, long firstServerSalt, int? expirationDate = null, bool? isBound = null)
        {
            lock (Mutex)
            {
                _authKey = authKey;
                _authKeyId = authKeyId;
                _firstSalt = firstServerSalt;
                _expirationDate = expirationDate;
                _isBound = isBound;
                OnDataUpdated();
            }
        }

        public (byte[] Key, long KeyId, long Salt, int? ExpirationDate, bool? IsBound)? GetData()
        {
            lock (Mutex)
            {
                if (_authKeyId == null)
                {
                    return null;
                }

                return (_authKey!, _authKeyId!.Value, _firstSalt!.Value, _expirationDate, _isBound);
            }
        }

        public void Read(Reader reader)
        {
            lock (Mutex)
            {
                if (reader.Read<bool>())
                {
                    _authKey = reader.Read<byte[]>();
                    _authKeyId = reader.Read<long>();
                    _firstSalt = reader.Read<long>();
                    var isTemp = reader.Read<bool>();
                    if (isTemp)
                    {
                        _expirationDate = reader.Read<int>();
                        _isBound = reader.Read<bool>();
                    }
                }
            }
        }

        public void Save(Writer writer)
        {
            lock (Mutex)
            {
                if (_authKeyId != null)
                {
                    writer.Write(true);
                    writer.Write(_authKey);
                    writer.Write(_authKeyId);
                    writer.Write(_firstSalt);
                    if (_expirationDate.HasValue && _isBound.HasValue)
                    {
                        writer.Write(true);
                        writer.Write(_expirationDate.Value);
                        writer.Write(_isBound.Value);
                    }
                    else
                    {
                        writer.Write(false);
                    }
                }
                else
                {
                    writer.Write(false);
                }
            }
        }
    }
}