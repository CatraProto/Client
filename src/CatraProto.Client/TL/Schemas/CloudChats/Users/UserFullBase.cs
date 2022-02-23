using CatraProto.TL;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Users
{
    public abstract class UserFullBase : IObject
    {

[Newtonsoft.Json.JsonProperty("full_user")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.UserFullBase FullUser { get; set; }

[Newtonsoft.Json.JsonProperty("chats")]
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> Chats { get; set; }

[Newtonsoft.Json.JsonProperty("users")]
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
