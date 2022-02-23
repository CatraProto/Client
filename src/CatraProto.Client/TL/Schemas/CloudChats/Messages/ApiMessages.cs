using System.Collections.Generic;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class ApiMessages : CatraProto.Client.TL.Schemas.CloudChats.Messages.MessagesBase
    {
        public static int StaticConstructorId
        {
            get => -1938715001;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("messages")]
        public IList<CatraProto.Client.TL.Schemas.CloudChats.MessageBase> Messages { get; set; }

        [Newtonsoft.Json.JsonProperty("chats")]
        public IList<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> Chats { get; set; }

        [Newtonsoft.Json.JsonProperty("users")]
        public IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }


    #nullable enable
        public ApiMessages(IList<CatraProto.Client.TL.Schemas.CloudChats.MessageBase> messages, IList<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> chats, IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> users)
        {
            Messages = messages;
            Chats = chats;
            Users = users;
        }
    #nullable disable
        internal ApiMessages()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(Messages);
            writer.Write(Chats);
            writer.Write(Users);
        }

        public override void Deserialize(Reader reader)
        {
            Messages = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.MessageBase>();
            Chats = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.ChatBase>();
            Users = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.UserBase>();
        }

        public override string ToString()
        {
            return "messages.messages";
        }
    }
}