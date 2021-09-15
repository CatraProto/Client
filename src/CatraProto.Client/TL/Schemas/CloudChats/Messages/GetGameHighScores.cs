using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class GetGameHighScores : IMethod
    {
        [JsonIgnore]
        public static int StaticConstructorId
        {
            get => -400399203;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(HighScoresBase);

        [JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [JsonProperty("peer")] public InputPeerBase Peer { get; set; }

        [JsonProperty("id")] public int Id { get; set; }

        [JsonProperty("user_id")] public InputUserBase UserId { get; set; }

        public override string ToString()
        {
            return "messages.getGameHighScores";
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

            writer.Write(Peer);
            writer.Write(Id);
            writer.Write(UserId);
        }

        public void Deserialize(Reader reader)
        {
            Peer = reader.Read<InputPeerBase>();
            Id = reader.Read<int>();
            UserId = reader.Read<InputUserBase>();
        }
    }
}