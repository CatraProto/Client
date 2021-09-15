using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Channels
{
    public partial class GetParticipants : IMethod
    {
        [JsonIgnore]
        public static int StaticConstructorId
        {
            get => 306054633;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(ChannelParticipantsBase);

        [JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [JsonProperty("channel")] public InputChannelBase Channel { get; set; }

        [JsonProperty("filter")] public ChannelParticipantsFilterBase Filter { get; set; }

        [JsonProperty("offset")] public int Offset { get; set; }

        [JsonProperty("limit")] public int Limit { get; set; }

        [JsonProperty("hash")] public int Hash { get; set; }

        public override string ToString()
        {
            return "channels.getParticipants";
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
            writer.Write(Filter);
            writer.Write(Offset);
            writer.Write(Limit);
            writer.Write(Hash);
        }

        public void Deserialize(Reader reader)
        {
            Channel = reader.Read<InputChannelBase>();
            Filter = reader.Read<ChannelParticipantsFilterBase>();
            Offset = reader.Read<int>();
            Limit = reader.Read<int>();
            Hash = reader.Read<int>();
        }
    }
}