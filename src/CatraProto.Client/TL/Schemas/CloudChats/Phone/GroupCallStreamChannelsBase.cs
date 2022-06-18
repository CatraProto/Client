using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Phone
{
    public abstract class GroupCallStreamChannelsBase : IObject
    {

        [Newtonsoft.Json.JsonProperty("channels")]
        public abstract List<CatraProto.Client.TL.Schemas.CloudChats.GroupCallStreamChannelBase> Channels { get; set; }

        public abstract void UpdateFlags();
        public abstract ReadResult<IObject> Deserialize(Reader reader);
        public abstract WriteResult Serialize(Writer writer);
        public abstract int GetConstructorId();
#nullable enable
        public abstract IObject? Clone();
        public abstract bool Compare(IObject other);
#nullable disable
    }
}
