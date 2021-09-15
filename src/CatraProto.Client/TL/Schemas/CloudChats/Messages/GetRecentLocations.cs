using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class GetRecentLocations : IMethod
    {
        [JsonIgnore]
        public static int StaticConstructorId
        {
            get => -1144759543;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(MessagesBase);

        [JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [JsonProperty("peer")] public InputPeerBase Peer { get; set; }

        [JsonProperty("limit")] public int Limit { get; set; }

        [JsonProperty("hash")] public int Hash { get; set; }

        public override string ToString()
        {
            return "messages.getRecentLocations";
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
            writer.Write(Limit);
            writer.Write(Hash);
        }

        public void Deserialize(Reader reader)
        {
            Peer = reader.Read<InputPeerBase>();
            Limit = reader.Read<int>();
            Hash = reader.Read<int>();
        }
    }
}