using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class ReceivedQueue : IMethod
    {
        [JsonIgnore]
        public static int StaticConstructorId
        {
            get => 1436924774;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(long);

        [JsonIgnore] bool IMethod.IsVector { get; init; } = true;

        [JsonProperty("max_qts")] public int MaxQts { get; set; }

        public override string ToString()
        {
            return "messages.receivedQueue";
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

            writer.Write(MaxQts);
        }

        public void Deserialize(Reader reader)
        {
            MaxQts = reader.Read<int>();
        }
    }
}