using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class GetHistory : IMethod
    {
        [JsonIgnore]
        public static int StaticConstructorId
        {
            get => -591691168;
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

        [JsonProperty("offset_date")] public int OffsetDate { get; set; }

        [JsonProperty("add_offset")] public int AddOffset { get; set; }

        [JsonProperty("limit")] public int Limit { get; set; }

        [JsonProperty("max_id")] public int MaxId { get; set; }

        [JsonProperty("min_id")] public int MinId { get; set; }

        [JsonProperty("hash")] public int Hash { get; set; }

        public override string ToString()
        {
            return "messages.getHistory";
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
            writer.Write(OffsetDate);
            writer.Write(AddOffset);
            writer.Write(Limit);
            writer.Write(MaxId);
            writer.Write(MinId);
            writer.Write(Hash);
        }

        public void Deserialize(Reader reader)
        {
            Peer = reader.Read<InputPeerBase>();
            OffsetId = reader.Read<int>();
            OffsetDate = reader.Read<int>();
            AddOffset = reader.Read<int>();
            Limit = reader.Read<int>();
            MaxId = reader.Read<int>();
            MinId = reader.Read<int>();
            Hash = reader.Read<int>();
        }
    }
}