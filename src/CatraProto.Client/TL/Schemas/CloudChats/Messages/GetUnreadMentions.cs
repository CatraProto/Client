using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class GetUnreadMentions : IMethod
    {
        [JsonIgnore]
        public static int StaticConstructorId
        {
            get => 1180140658;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(MessagesBase);

        [JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [JsonProperty("peer")] public InputPeerBase Peer { get; set; }

        [JsonProperty("offset_id")] public int OffsetId { get; set; }

        [JsonProperty("add_offset")] public int AddOffset { get; set; }

        [JsonProperty("limit")] public int Limit { get; set; }

        [JsonProperty("max_id")] public int MaxId { get; set; }

        [JsonProperty("min_id")] public int MinId { get; set; }

        public override string ToString()
        {
            return "messages.getUnreadMentions";
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
            writer.Write(OffsetId);
            writer.Write(AddOffset);
            writer.Write(Limit);
            writer.Write(MaxId);
            writer.Write(MinId);
        }

        public void Deserialize(Reader reader)
        {
            Peer = reader.Read<InputPeerBase>();
            OffsetId = reader.Read<int>();
            AddOffset = reader.Read<int>();
            Limit = reader.Read<int>();
            MaxId = reader.Read<int>();
            MinId = reader.Read<int>();
        }
    }
}