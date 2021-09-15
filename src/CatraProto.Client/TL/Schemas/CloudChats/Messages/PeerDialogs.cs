using System.Collections.Generic;
using CatraProto.Client.TL.Schemas.CloudChats.Updates;
using CatraProto.TL;
using Newtonsoft.Json;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class PeerDialogs : PeerDialogsBase
    {
        public static int StaticConstructorId
        {
            get => 863093588;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonProperty("dialogs")] public override IList<DialogBase> Dialogs { get; set; }

        [JsonProperty("messages")] public override IList<MessageBase> Messages { get; set; }

        [JsonProperty("chats")] public override IList<ChatBase> Chats { get; set; }

        [JsonProperty("users")] public override IList<UserBase> Users { get; set; }

        [JsonProperty("state")] public override StateBase State { get; set; }


        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            writer.Write(Dialogs);
            writer.Write(Messages);
            writer.Write(Chats);
            writer.Write(Users);
            writer.Write(State);
        }

        public override void Deserialize(Reader reader)
        {
            Dialogs = reader.ReadVector<DialogBase>();
            Messages = reader.ReadVector<MessageBase>();
            Chats = reader.ReadVector<ChatBase>();
            Users = reader.ReadVector<UserBase>();
            State = reader.Read<StateBase>();
        }

        public override string ToString()
        {
            return "messages.peerDialogs";
        }
    }
}