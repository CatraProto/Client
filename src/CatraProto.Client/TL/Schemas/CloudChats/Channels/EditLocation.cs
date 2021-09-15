using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Channels
{
    public partial class EditLocation : IMethod
    {
        [JsonIgnore]
        public static int StaticConstructorId
        {
            get => 1491484525;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(bool);

        [JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [JsonProperty("channel")] public InputChannelBase Channel { get; set; }

        [JsonProperty("geo_point")] public InputGeoPointBase GeoPoint { get; set; }

        [JsonProperty("address")] public string Address { get; set; }

        public override string ToString()
        {
            return "channels.editLocation";
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
            writer.Write(GeoPoint);
            writer.Write(Address);
        }

        public void Deserialize(Reader reader)
        {
            Channel = reader.Read<InputChannelBase>();
            GeoPoint = reader.Read<InputGeoPointBase>();
            Address = reader.Read<string>();
        }
    }
}