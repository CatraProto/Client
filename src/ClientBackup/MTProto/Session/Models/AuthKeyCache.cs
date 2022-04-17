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
                if (reader.ReadBool().Value)
                {
                    _authKey = reader.ReadBytes().Value;
                    _authKeyId = reader.ReadInt64().Value;
                    _firstSalt = reader.ReadInt64().Value;
                    var isTemp = reader.ReadBool().Value;
                    if (isTemp)
                    {
                        _expirationDate = reader.ReadInt32().Value;
                        _isBound = reader.ReadBool().Value;
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
                    writer.WriteBool(true);
                    writer.WriteBytes(_authKey!);
                    writer.WriteInt64(_authKeyId!.Value);
                    writer.WriteInt64(_firstSalt!.Value);
                    if (_expirationDate.HasValue && _isBound.HasValue)
                    {
                        writer.WriteBool(true);
                        writer.WriteInt32(_expirationDate.Value);
                        writer.WriteBool(_isBound.Value);
                    }
                    else
                    {
                        writer.WriteBool(false);
                    }
                }
                else
                {
                    writer.WriteBool(false);
                }
            }
        }
    }
}