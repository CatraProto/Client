using System.Collections.Generic;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class MessageActionChatCreate : CatraProto.Client.TL.Schemas.CloudChats.MessageActionBase
    {
        public static int StaticConstructorId
        {
            get => -1119368275;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("title")]
        public string Title { get; set; }

        [Newtonsoft.Json.JsonProperty("users")]
        public IList<long> Users { get; set; }


    #nullable enable
        public MessageActionChatCreate(string title, IList<long> users)
        {
            Title = title;
            Users = users;
        }
    #nullable disable
        internal MessageActionChatCreate()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(Title);
            writer.Write(Users);
        }

        public override void Deserialize(Reader reader)
        {
            Title = reader.Read<string>();
            Users = reader.ReadVector<long>();
        }

        public override string ToString()
        {
            return "messageActionChatCreate";
        }
    }
}