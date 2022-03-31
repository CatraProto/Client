using CatraProto.Client.TL.Schemas;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
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

        public void Deserialize(Reader reader)
        {
            UpdatedAt = reader.Read<int>();
            LayerVersion = reader.Read<int>();
            if (LayerVersion == MergedProvider.LayerId)
            {
                Object = reader.Read<IObject>();
            }
            else
            {
                Object = null;
            }
        }

        public int GetConstructorId()
        {
            throw new NotImplementedException();
        }

        public void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(UpdatedAt);
            writer.Write(LayerVersion);
            writer.Write(Object);
        }

        public void UpdateFlags()
        {
        }
    }
}
