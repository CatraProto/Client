using System;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class VideoSize : VideoSizeBase
    {
        public static int ConstructorId { get; } = -399391402;
        public int Flags { get; set; }
        public override string Type { get; set; }
        public override FileLocationBase Location { get; set; }
        public override int W { get; set; }
        public override int H { get; set; }
        public override int Size { get; set; }
        public override double? VideoStartTs { get; set; }

        [Flags]
        public enum FlagsEnum
        {
            VideoStartTs = 1 << 0
        }

        public override void UpdateFlags()
        {
            Flags = VideoStartTs == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            UpdateFlags();
            writer.Write(Flags);
            writer.Write(Type);
            writer.Write(Location);
            writer.Write(W);
            writer.Write(H);
            writer.Write(Size);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                writer.Write(VideoStartTs);
            }
        }

        public override void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            Type = reader.Read<string>();
            Location = reader.Read<FileLocationBase>();
            W = reader.Read<int>();
            H = reader.Read<int>();
            Size = reader.Read<int>();
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                VideoStartTs = reader.Read<double>();
            }
        }
    }
}