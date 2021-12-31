using CatraProto.TL;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Phone
{
    public abstract class GroupCallBase : IObject
    {

[Newtonsoft.Json.JsonProperty("call")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.GroupCallBase Call { get; set; }

[Newtonsoft.Json.JsonProperty("participants")]
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.GroupCallParticipantBase> Participants { get; set; }

[Newtonsoft.Json.JsonProperty("participants_next_offset")]
		public abstract string ParticipantsNextOffset { get; set; }

[Newtonsoft.Json.JsonProperty("chats")]
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> Chats { get; set; }

[Newtonsoft.Json.JsonProperty("users")]
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
