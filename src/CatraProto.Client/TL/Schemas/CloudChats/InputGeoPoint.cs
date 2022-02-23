using System;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class InputGeoPoint : CatraProto.Client.TL.Schemas.CloudChats.InputGeoPointBase
    {
        [Flags]
        public enum FlagsEnum
        {
            AccuracyRadius = 1 << 0
        }

        public static int StaticConstructorId
        {
            get => 1210199983;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("lat")] public double Lat { get; set; }

        [Newtonsoft.Json.JsonProperty("long")] public double Long { get; set; }

        [Newtonsoft.Json.JsonProperty("accuracy_radius")]
        public int? AccuracyRadius { get; set; }


    #nullable enable
        public InputGeoPoint(double lat, double llong)
        {
            Lat = lat;
            Long = llong;
        }
    #nullable disable
        internal InputGeoPoint()
        {
        }

        public override void UpdateFlags()
        {
            Flags = AccuracyRadius == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            UpdateFlags();
            writer.Write(Flags);
            writer.Write(Lat);
            writer.Write(Long);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                writer.Write(AccuracyRadius.Value);
            }
        }

        public override void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            Lat = reader.Read<double>();
            Long = reader.Read<double>();
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                AccuracyRadius = reader.Read<int>();
            }
        }

        public override string ToString()
        {
            return "inputGeoPoint";
        }
    }
}