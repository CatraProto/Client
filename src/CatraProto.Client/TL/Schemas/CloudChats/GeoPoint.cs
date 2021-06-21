using System;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class GeoPoint : GeoPointBase
    {
        public static int ConstructorId { get; } = -1297942941;
        public int Flags { get; set; }
        public double Long { get; set; }
        public double Lat { get; set; }
        public long AccessHash { get; set; }
        public int? AccuracyRadius { get; set; }

        [Flags]
        public enum FlagsEnum
        {
            AccuracyRadius = 1 << 0
        }

        public override void UpdateFlags()
        {
            Flags = AccuracyRadius == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            UpdateFlags();
            writer.Write(Flags);
            writer.Write(Long);
            writer.Write(Lat);
            writer.Write(AccessHash);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                writer.Write(AccuracyRadius.Value);
            }
        }

        public override void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            Long = reader.Read<double>();
            Lat = reader.Read<double>();
            AccessHash = reader.Read<long>();
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                AccuracyRadius = reader.Read<int>();
            }
        }
    }
}