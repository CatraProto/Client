using System.Collections.Generic;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class MessageViews : CatraProto.Client.TL.Schemas.CloudChats.Messages.MessageViewsBase
    {
        public static int StaticConstructorId
        {
            get => -1228606141;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("views")]
        public sealed override IList<CatraProto.Client.TL.Schemas.CloudChats.MessageViewsBase> Views { get; set; }

        [Newtonsoft.Json.JsonProperty("chats")]
        public sealed override IList<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> Chats { get; set; }

        [Newtonsoft.Json.JsonProperty("users")]
        public sealed override IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }


    #nullable enable
        public MessageViews(IList<CatraProto.Client.TL.Schemas.CloudChats.MessageViewsBase> views, IList<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> chats, IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> users)
        {
            Views = views;
            Chats = chats;
            Users = users;
        }
    #nullable disable
        internal MessageViews()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(Views);
            writer.Write(Chats);
            writer.Write(Users);
        }

        public override void Deserialize(Reader reader)
        {
            Views = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.MessageViewsBase>();
            Chats = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.ChatBase>();
            Users = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.UserBase>();
        }

        public override string ToString()
        {
            return "messages.messageViews";
        }
    }
}