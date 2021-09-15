using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class EditChatPhoto : IMethod
    {
        [JsonIgnore]
        public static int StaticConstructorId
        {
            get => -900957736;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(UpdatesBase);

        [JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [JsonProperty("chat_id")] public int ChatId { get; set; }

        [JsonProperty("photo")] public InputChatPhotoBase Photo { get; set; }

        public override string ToString()
        {
            return "messages.editChatPhoto";
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
            writer.Write(Photo);
        }

        public void Deserialize(Reader reader)
        {
            ChatId = reader.Read<int>();
            Photo = reader.Read<InputChatPhotoBase>();
        }
    }
}