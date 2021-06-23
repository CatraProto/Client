using System;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public class StatsGraph : StatsGraphBase
    {
        [Flags]
        public enum FlagsEnum
        {
            ZoomToken = 1 << 0
        }

        public static int ConstructorId { get; } = -1901828938;
        public int Flags { get; set; }
        public DataJSONBase Json { get; set; }
        public string ZoomToken { get; set; }

        public override void UpdateFlags()
        {
            Flags = ZoomToken == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            UpdateFlags();
            writer.Write(Flags);
            writer.Write(Json);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                writer.Write(ZoomToken);
            }
        }

        public override void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            Json = reader.Read<DataJSONBase>();
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                ZoomToken = reader.Read<string>();
            }
        }
    }
}