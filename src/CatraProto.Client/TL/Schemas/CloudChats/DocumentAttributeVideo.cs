using System;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class DocumentAttributeVideo : DocumentAttributeBase
    {
        public static int ConstructorId { get; } = 250621158;
        public int Flags { get; set; }
        public bool RoundMessage { get; set; }
        public bool SupportsStreaming { get; set; }
        public int Duration { get; set; }
        public int W { get; set; }
        public int H { get; set; }

        [Flags]
        public enum FlagsEnum
        {
            RoundMessage = 1 << 0,
            SupportsStreaming = 1 << 1
        }

        public override void UpdateFlags()
        {
            Flags = RoundMessage ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
            Flags = SupportsStreaming ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            UpdateFlags();
            writer.Write(Flags);
            writer.Write(Duration);
            writer.Write(W);
            writer.Write(H);
        }

        public override void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            RoundMessage = FlagsHelper.IsFlagSet(Flags, 0);
            SupportsStreaming = FlagsHelper.IsFlagSet(Flags, 1);
            Duration = reader.Read<int>();
            W = reader.Read<int>();
            H = reader.Read<int>();
        }
    }
}