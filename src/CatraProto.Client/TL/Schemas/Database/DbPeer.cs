using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

namespace CatraProto.Client.TL.Schemas.Database
{
    internal class DbPeer : IObject
    {
        public static int ConstructorId { get => 1823163441; }
        public long AccessHash { get; set; }
        public int LayerVersion { get; set; }
        public IObject? Object { get; set; }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var checkLength = reader.CheckLength<IObject>(12);
            if (checkLength.IsError)
            {
                return checkLength;
            }

            AccessHash = reader.ReadInt64().Value;
            LayerVersion = reader.ReadInt32().Value;
            if (LayerVersion == MergedProvider.LayerId)
            {
                var tryRead = reader.ReadObject();
                if (tryRead.IsError)
                {
                    Object = null;
                    return tryRead;
                }
                else
                {
                    Object = tryRead.Value;
                }
            }
            else
            {
                Object = null;
            }

            return new ReadResult<IObject>(this);
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt64(AccessHash);
            writer.WriteInt32(LayerVersion);
            if (Object is null)
            {
                return new WriteResult("Object is null", ParserErrors.NullValue);
            }

            var obj = writer.WriteObject(Object);
            if (obj.IsError)
            {
                return obj;
            }

            return new WriteResult();
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }

        public void UpdateFlags()
        {
        }

        public IObject? Clone()
        {
            var newObj = new DbPeer
            {
                AccessHash = AccessHash,
                LayerVersion = LayerVersion
            };
            if (Object is not null)
            {
                newObj.Object = Object.Clone();
            }

            return newObj;
        }
    }
}
