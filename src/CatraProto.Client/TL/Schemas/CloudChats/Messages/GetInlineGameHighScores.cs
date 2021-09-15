using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class GetInlineGameHighScores : IMethod
    {
        [JsonIgnore]
        public static int StaticConstructorId
        {
            get => 258170395;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(HighScoresBase);

        [JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [JsonProperty("id")] public InputBotInlineMessageIDBase Id { get; set; }

        [JsonProperty("user_id")] public InputUserBase UserId { get; set; }

        public override string ToString()
        {
            return "messages.getInlineGameHighScores";
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

            writer.Write(Id);
            writer.Write(UserId);
        }

        public void Deserialize(Reader reader)
        {
            Id = reader.Read<InputBotInlineMessageIDBase>();
            UserId = reader.Read<InputUserBase>();
        }
    }
}