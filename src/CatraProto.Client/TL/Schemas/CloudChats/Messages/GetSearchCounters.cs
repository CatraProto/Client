using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class GetSearchCounters : IMethod
    {
        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId
        {
            get => 1932455680;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonIgnore] System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Messages.SearchCounterBase);

        [Newtonsoft.Json.JsonIgnore] bool IMethod.IsVector { get; init; } = true;

        [Newtonsoft.Json.JsonProperty("peer")] public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase Peer { get; set; }

        [Newtonsoft.Json.JsonProperty("filters")]
        public IList<CatraProto.Client.TL.Schemas.CloudChats.MessagesFilterBase> Filters { get; set; }


    #nullable enable
        public GetSearchCounters(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, IList<CatraProto.Client.TL.Schemas.CloudChats.MessagesFilterBase> filters)
        {
            Peer = peer;
            Filters = filters;
        }
    #nullable disable

        internal GetSearchCounters()
        {
        }

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(Peer);
            writer.Write(Filters);
        }

        public void Deserialize(Reader reader)
        {
            Peer = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase>();
            Filters = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.MessagesFilterBase>();
        }

        public override string ToString()
        {
            return "messages.getSearchCounters";
        }
    }
}