using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class AddChatUser : IMethod
    {
        [JsonIgnore]
        public static int StaticConstructorId
        {
            get => -106911223;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(UpdatesBase);

        [JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [JsonProperty("chat_id")] public int ChatId { get; set; }

        [JsonProperty("user_id")] public InputUserBase UserId { get; set; }

        [JsonProperty("fwd_limit")] public int FwdLimit { get; set; }

        public override string ToString()
        {
            return "messages.addChatUser";
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
            writer.Write(FwdLimit);
        }

        public void Deserialize(Reader reader)
        {
            ChatId = reader.Read<int>();
            UserId = reader.Read<InputUserBase>();
            FwdLimit = reader.Read<int>();
        }
    }
}