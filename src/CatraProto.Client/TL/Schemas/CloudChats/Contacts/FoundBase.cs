using CatraProto.TL;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Contacts
{
    public abstract class FoundBase : IObject
    {

[JsonPropertyName("my_results")]
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.PeerBase> MyResults { get; set; }

[JsonPropertyName("results")]
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.PeerBase> Results { get; set; }

[JsonPropertyName("chats")]
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> Chats { get; set; }

[JsonPropertyName("users")]
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
