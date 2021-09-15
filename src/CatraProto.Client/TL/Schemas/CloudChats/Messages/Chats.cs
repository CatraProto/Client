using System.Collections.Generic;
using CatraProto.TL;
using Newtonsoft.Json;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class Chats : ChatsBase
    {
        public static int StaticConstructorId
        {
            get => 1694474197;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonProperty("chats")] public override IList<ChatBase> ChatsField { get; set; }


        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            writer.Write(ChatsField);
        }

        public override void Deserialize(Reader reader)
        {
            ChatsField = reader.ReadVector<ChatBase>();
        }

        public override string ToString()
        {
            return "messages.chats";
        }
    }
}