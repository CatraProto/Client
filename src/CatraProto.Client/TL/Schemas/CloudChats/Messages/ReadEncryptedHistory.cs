using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class ReadEncryptedHistory : IMethod
    {
        [JsonIgnore]
        public static int StaticConstructorId
        {
            get => 2135648522;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(bool);

        [JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [JsonProperty("peer")] public InputEncryptedChatBase Peer { get; set; }

        [JsonProperty("max_date")] public int MaxDate { get; set; }

        public override string ToString()
        {
            return "messages.readEncryptedHistory";
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
            writer.Write(MaxDate);
        }

        public void Deserialize(Reader reader)
        {
            Peer = reader.Read<InputEncryptedChatBase>();
            MaxDate = reader.Read<int>();
        }
    }
}