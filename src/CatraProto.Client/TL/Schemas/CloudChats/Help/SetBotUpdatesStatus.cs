using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Help
{
    public partial class SetBotUpdatesStatus : IMethod
    {
        [JsonIgnore]
        public static int StaticConstructorId
        {
            get => -333262899;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(bool);

        [JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [JsonProperty("pending_updates_count")]
        public int PendingUpdatesCount { get; set; }

        [JsonProperty("message")] public string Message { get; set; }

        public override string ToString()
        {
            return "help.setBotUpdatesStatus";
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

            writer.Write(PendingUpdatesCount);
            writer.Write(Message);
        }

        public void Deserialize(Reader reader)
        {
            PendingUpdatesCount = reader.Read<int>();
            Message = reader.Read<string>();
        }
    }
}