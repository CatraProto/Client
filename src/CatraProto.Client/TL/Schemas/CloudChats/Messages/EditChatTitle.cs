using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class EditChatTitle : IMethod
    {
        [JsonIgnore]
        public static int StaticConstructorId
        {
            get => -599447467;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(UpdatesBase);

        [JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [JsonProperty("chat_id")] public int ChatId { get; set; }

        [JsonProperty("title")] public string Title { get; set; }

        public override string ToString()
        {
            return "messages.editChatTitle";
        }


        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            writer.Write(ChatId);
            writer.Write(Title);
        }

        public void Deserialize(Reader reader)
        {
            ChatId = reader.Read<int>();
            Title = reader.Read<string>();
        }
    }
}