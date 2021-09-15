using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class EditChatAdmin : IMethod
    {
        [JsonIgnore]
        public static int StaticConstructorId
        {
            get => -1444503762;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(bool);

        [JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [JsonProperty("chat_id")] public int ChatId { get; set; }

        [JsonProperty("user_id")] public InputUserBase UserId { get; set; }

        [JsonProperty("is_admin")] public bool IsAdmin { get; set; }

        public override string ToString()
        {
            return "messages.editChatAdmin";
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
            writer.Write(UserId);
            writer.Write(IsAdmin);
        }

        public void Deserialize(Reader reader)
        {
            ChatId = reader.Read<int>();
            UserId = reader.Read<InputUserBase>();
            IsAdmin = reader.Read<bool>();
        }
    }
}