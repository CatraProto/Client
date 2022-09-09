using CatraProto.TL;
using CatraProto.TL.Results;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using CatraProto.TL.Interfaces;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Phone
{
    public abstract class GroupParticipantsBase : IObject
    {
        [Newtonsoft.Json.JsonProperty("count")]
        public abstract int Count { get; set; }

        [Newtonsoft.Json.JsonProperty("participants")]
        public abstract List<CatraProto.Client.TL.Schemas.CloudChats.GroupCallParticipantBase> Participants { get; set; }

        [Newtonsoft.Json.JsonProperty("next_offset")]
        public abstract string NextOffset { get; set; }

        [Newtonsoft.Json.JsonProperty("chats")]
        public abstract List<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> Chats { get; set; }

        [Newtonsoft.Json.JsonProperty("users")]
        public abstract List<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }

        [Newtonsoft.Json.JsonProperty("version")]
        public abstract int Version { get; set; }

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