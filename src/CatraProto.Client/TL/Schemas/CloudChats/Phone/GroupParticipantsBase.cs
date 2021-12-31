using CatraProto.TL;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Phone
{
    public abstract class GroupParticipantsBase : IObject
    {

[Newtonsoft.Json.JsonProperty("count")]
		public abstract int Count { get; set; }

[Newtonsoft.Json.JsonProperty("participants")]
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.GroupCallParticipantBase> Participants { get; set; }

[Newtonsoft.Json.JsonProperty("next_offset")]
		public abstract string NextOffset { get; set; }

[Newtonsoft.Json.JsonProperty("chats")]
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> Chats { get; set; }

[Newtonsoft.Json.JsonProperty("users")]
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }

[Newtonsoft.Json.JsonProperty("version")]
		public abstract int Version { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}