using System.Collections.Generic;
using CatraProto.TL;
using Newtonsoft.Json;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class DialogsSlice : DialogsBase
    {
        public static int StaticConstructorId
        {
            get => 1910543603;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonProperty("count")] public int Count { get; set; }

        [JsonProperty("dialogs")] public IList<DialogBase> Dialogs { get; set; }

        [JsonProperty("messages")] public IList<MessageBase> Messages { get; set; }

        [JsonProperty("chats")] public IList<ChatBase> Chats { get; set; }

        [JsonProperty("users")] public IList<UserBase> Users { get; set; }


        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            writer.Write(Count);
            writer.Write(Dialogs);
            writer.Write(Messages);
            writer.Write(Chats);
            writer.Write(Users);
        }

        public override void Deserialize(Reader reader)
        {
            Count = reader.Read<int>();
            Dialogs = reader.ReadVector<DialogBase>();
            Messages = reader.ReadVector<MessageBase>();
            Chats = reader.ReadVector<ChatBase>();
            Users = reader.ReadVector<UserBase>();
        }

        public override string ToString()
        {
            return "messages.dialogsSlice";
        }
    }
}