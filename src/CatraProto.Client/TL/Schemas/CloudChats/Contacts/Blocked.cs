using System.Collections.Generic;
using CatraProto.TL;
using Newtonsoft.Json;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Contacts
{
    public partial class Blocked : BlockedBase
    {
        public static int StaticConstructorId
        {
            get => 182326673;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonProperty("blocked")] public override IList<PeerBlockedBase> BlockedField { get; set; }

        [JsonProperty("chats")] public override IList<ChatBase> Chats { get; set; }

        [JsonProperty("users")] public override IList<UserBase> Users { get; set; }


        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            writer.Write(BlockedField);
            writer.Write(Chats);
            writer.Write(Users);
        }

        public override void Deserialize(Reader reader)
        {
            BlockedField = reader.ReadVector<PeerBlockedBase>();
            Chats = reader.ReadVector<ChatBase>();
            Users = reader.ReadVector<UserBase>();
        }

        public override string ToString()
        {
            return "contacts.blocked";
        }
    }
}