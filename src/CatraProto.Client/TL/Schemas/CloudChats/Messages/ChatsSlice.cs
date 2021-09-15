using System.Collections.Generic;
using CatraProto.TL;
using Newtonsoft.Json;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class ChatsSlice : ChatsBase
    {
        public static int StaticConstructorId
        {
            get => -1663561404;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonProperty("count")] public int Count { get; set; }

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

            writer.Write(Count);
            writer.Write(ChatsField);
        }

        public override void Deserialize(Reader reader)
        {
            Count = reader.Read<int>();
            ChatsField = reader.ReadVector<ChatBase>();
        }

        public override string ToString()
        {
            return "messages.chatsSlice";
        }
    }
}