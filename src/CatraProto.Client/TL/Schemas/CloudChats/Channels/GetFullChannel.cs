using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Channels
{
    public partial class GetFullChannel : IMethod
    {
        [JsonIgnore]
        public static int StaticConstructorId
        {
            get => 141781513;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(Messages.ChatFullBase);

        [JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [JsonProperty("channel")] public InputChannelBase Channel { get; set; }

        public override string ToString()
        {
            return "channels.getFullChannel";
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