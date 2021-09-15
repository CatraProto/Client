using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class ReceivedMessages : IMethod
    {
        [JsonIgnore]
        public static int StaticConstructorId
        {
            get => 94983360;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(ReceivedNotifyMessageBase);

        [JsonIgnore] bool IMethod.IsVector { get; init; } = true;

        [JsonProperty("max_id")] public int MaxId { get; set; }

        public override string ToString()
        {
            return "messages.receivedMessages";
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

            writer.Write(MaxId);
        }

        public void Deserialize(Reader reader)
        {
            MaxId = reader.Read<int>();
        }
    }
}