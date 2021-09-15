using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Channels
{
    public partial class DeleteChannel : IMethod
    {
        [JsonIgnore]
        public static int StaticConstructorId
        {
            get => -1072619549;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(UpdatesBase);

        [JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [JsonProperty("channel")] public InputChannelBase Channel { get; set; }

        public override string ToString()
        {
            return "channels.deleteChannel";
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
        }

        public void Deserialize(Reader reader)
        {
            Channel = reader.Read<InputChannelBase>();
        }
    }
}