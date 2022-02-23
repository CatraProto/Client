using System.Collections.Generic;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Contacts
{
    public partial class BlockedSlice : CatraProto.Client.TL.Schemas.CloudChats.Contacts.BlockedBase
    {
        public static int StaticConstructorId
        {
            get => -513392236;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("count")]
        public int Count { get; set; }

        [Newtonsoft.Json.JsonProperty("blocked")]
        public sealed override IList<CatraProto.Client.TL.Schemas.CloudChats.PeerBlockedBase> BlockedField { get; set; }

        [Newtonsoft.Json.JsonProperty("chats")]
        public sealed override IList<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> Chats { get; set; }

        [Newtonsoft.Json.JsonProperty("users")]
        public sealed override IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }


    #nullable enable
        public BlockedSlice(int count, IList<CatraProto.Client.TL.Schemas.CloudChats.PeerBlockedBase> blockedField, IList<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> chats, IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> users)
        {
            Count = count;
            BlockedField = blockedField;
            Chats = chats;
            Users = users;
        }
    #nullable disable
        internal BlockedSlice()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(Count);
            writer.Write(BlockedField);
            writer.Write(Chats);
            writer.Write(Users);
        }

        public override void Deserialize(Reader reader)
        {
            Count = reader.Read<int>();
            BlockedField = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.PeerBlockedBase>();
            Chats = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.ChatBase>();
            Users = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.UserBase>();
        }

        public override string ToString()
        {
            return "contacts.blockedSlice";
        }
    }
}