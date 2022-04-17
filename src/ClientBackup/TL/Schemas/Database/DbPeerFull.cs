using CatraProto.Client.TL.Schemas;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatraProto.Client.TL.Schemas.Database
{
    internal class DbPeerFull : IObject
    {
        public static int ConstructorId { get => 1111983006; }
        public long UpdatedAt { get; set; }
        public int LayerVersion { get; set; }
        public IObject? Object { get; set; }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var checkLength = reader.CheckLength<IObject>(8);
            if (checkLength.IsError)
            {
                return checkLength;
            }

            UpdatedAt = reader.ReadInt32().Value;
            LayerVersion = reader.ReadInt32().Value;
            if (LayerVersion == MergedProvider.LayerId)
            {
                var tryRead = reader.ReadObject();
                if (tryRead.IsError)
                {
                    Object = null;
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

        public int GetConstructorId()
        {
            return ConstructorId;
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt64(UpdatedAt);
            writer.WriteInt32(LayerVersion);
            if(Object is null)
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

        public void UpdateFlags()
        {
        }
    }
}
