using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class GetSearchCounters : IMethod
    {
        [JsonIgnore]
        public static int StaticConstructorId
        {
            get => 1932455680;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(SearchCounterBase);

        [JsonIgnore] bool IMethod.IsVector { get; init; } = true;

        [JsonProperty("peer")] public InputPeerBase Peer { get; set; }

        [JsonProperty("filters")] public IList<MessagesFilterBase> Filters { get; set; }

        public override string ToString()
        {
            return "messages.getSearchCounters";
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
            writer.Write(Filters);
        }

        public void Deserialize(Reader reader)
        {
            Peer = reader.Read<InputPeerBase>();
            Filters = reader.ReadVector<MessagesFilterBase>();
        }
    }
}