using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class GetMessagesViews : IMethod
    {
        [JsonIgnore]
        public static int StaticConstructorId
        {
            get => 1468322785;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(MessageViewsBase);

        [JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [JsonProperty("peer")] public InputPeerBase Peer { get; set; }

        [JsonProperty("id")] public IList<int> Id { get; set; }

        [JsonProperty("increment")] public bool Increment { get; set; }

        public override string ToString()
        {
            return "messages.getMessagesViews";
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
            writer.Write(Increment);
        }

        public void Deserialize(Reader reader)
        {
            Peer = reader.Read<InputPeerBase>();
            Id = reader.ReadVector<int>();
            Increment = reader.Read<bool>();
        }
    }
}