using CatraProto.TL;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Contacts
{
    public abstract class FoundBase : IObject
    {

[Newtonsoft.Json.JsonProperty("my_results")]
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.PeerBase> MyResults { get; set; }

[Newtonsoft.Json.JsonProperty("results")]
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.PeerBase> Results { get; set; }

[Newtonsoft.Json.JsonProperty("chats")]
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> Chats { get; set; }

[Newtonsoft.Json.JsonProperty("users")]
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
