using CatraProto.TL;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
namespace CatraProto.Client.TL.Schemas.CloudChats.Help
{
    public abstract class RecentMeUrlsBase : IObject
    {

[JsonPropertyName("urls")]
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.RecentMeUrlBase> Urls { get; set; }

[JsonPropertyName("chats")]
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> Chats { get; set; }

[JsonPropertyName("users")]
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
