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
    internal class DbPeer : IObject
    {
        public static int ConstructorId { get => 1823163441; }
        public long AccessHash { get; set; }
        public int LayerVersion { get; set; }
        public IObject? Object { get; set; }

        public void Deserialize(Reader reader)
        {
            AccessHash = reader.Read<long>();
            LayerVersion = reader.Read<int>();
            if(LayerVersion == MergedProvider.LayerId)
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
            writer.Write(AccessHash);
            writer.Write(LayerVersion);
            writer.Write(Object);
        }

        public void UpdateFlags()
        {
        }
    }
}
