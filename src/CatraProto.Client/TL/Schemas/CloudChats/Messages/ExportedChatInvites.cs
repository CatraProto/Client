using System.Collections.Generic;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class ExportedChatInvites : CatraProto.Client.TL.Schemas.CloudChats.Messages.ExportedChatInvitesBase
    {
        public static int StaticConstructorId
        {
            get => -1111085620;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("count")]
        public sealed override int Count { get; set; }

        [Newtonsoft.Json.JsonProperty("invites")]
        public sealed override IList<CatraProto.Client.TL.Schemas.CloudChats.ExportedChatInviteBase> Invites { get; set; }

        [Newtonsoft.Json.JsonProperty("users")]
        public sealed override IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }


    #nullable enable
        public ExportedChatInvites(int count, IList<CatraProto.Client.TL.Schemas.CloudChats.ExportedChatInviteBase> invites, IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> users)
        {
            Count = count;
            Invites = invites;
            Users = users;
        }
    #nullable disable
        internal ExportedChatInvites()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(Count);
            writer.Write(Invites);
            writer.Write(Users);
        }

        public override void Deserialize(Reader reader)
        {
            Count = reader.Read<int>();
            Invites = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.ExportedChatInviteBase>();
            Users = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.UserBase>();
        }

        public override string ToString()
        {
            return "messages.exportedChatInvites";
        }
    }
}