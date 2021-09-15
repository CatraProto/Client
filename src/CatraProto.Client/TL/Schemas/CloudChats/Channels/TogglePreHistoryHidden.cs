using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Channels
{
    public partial class TogglePreHistoryHidden : IMethod
    {
        [JsonIgnore]
        public static int StaticConstructorId
        {
            get => -356796084;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(UpdatesBase);

        [JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [JsonProperty("channel")] public InputChannelBase Channel { get; set; }

        [JsonProperty("enabled")] public bool Enabled { get; set; }

        public override string ToString()
        {
            return "channels.togglePreHistoryHidden";
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

            writer.Write(Channel);
            writer.Write(Enabled);
        }

        public void Deserialize(Reader reader)
        {
            Channel = reader.Read<InputChannelBase>();
            Enabled = reader.Read<bool>();
        }
    }
}