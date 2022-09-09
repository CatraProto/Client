using CatraProto.TL;
using CatraProto.TL.Results;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using CatraProto.TL.Interfaces;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Contacts
{
    public abstract class FoundBase : IObject
    {
        [Newtonsoft.Json.JsonProperty("my_results")]
        public abstract List<CatraProto.Client.TL.Schemas.CloudChats.PeerBase> MyResults { get; set; }

        [Newtonsoft.Json.JsonProperty("results")]
        public abstract List<CatraProto.Client.TL.Schemas.CloudChats.PeerBase> Results { get; set; }

        [Newtonsoft.Json.JsonProperty("chats")]
        public abstract List<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> Chats { get; set; }

        [Newtonsoft.Json.JsonProperty("users")]
        public abstract List<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }

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