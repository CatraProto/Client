using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class Report : IMethod
    {
        [JsonIgnore]
        public static int StaticConstructorId
        {
            get => -1115507112;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(bool);

        [JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [JsonProperty("peer")] public InputPeerBase Peer { get; set; }

        [JsonProperty("id")] public IList<int> Id { get; set; }

        [JsonProperty("reason")] public ReportReasonBase Reason { get; set; }

        public override string ToString()
        {
            return "messages.report";
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
            writer.Write(Reason);
        }

        public void Deserialize(Reader reader)
        {
            Peer = reader.Read<InputPeerBase>();
            Id = reader.ReadVector<int>();
            Reason = reader.Read<ReportReasonBase>();
        }
    }
}