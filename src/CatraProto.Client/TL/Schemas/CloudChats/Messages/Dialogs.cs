using System.Collections.Generic;
using CatraProto.TL;
using Newtonsoft.Json;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class Dialogs : DialogsBase
    {
        public static int StaticConstructorId
        {
            get => 364538944;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonProperty("dialogs")] public IList<DialogBase> DialogsField { get; set; }

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

            writer.Write(DialogsField);
            writer.Write(Messages);
            writer.Write(Chats);
            writer.Write(Users);
        }

        public override void Deserialize(Reader reader)
        {
            DialogsField = reader.ReadVector<DialogBase>();
            Messages = reader.ReadVector<MessageBase>();
            Chats = reader.ReadVector<ChatBase>();
            Users = reader.ReadVector<UserBase>();
        }

        public override string ToString()
        {
            return "messages.dialogs";
        }
    }
}