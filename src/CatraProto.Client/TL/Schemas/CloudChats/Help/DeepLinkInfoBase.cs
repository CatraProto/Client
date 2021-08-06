using CatraProto.TL;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Help
{
    public abstract class DeepLinkInfoBase : IObject
    {

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
