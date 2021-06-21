using System;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class InputMediaPhoto : InputMediaBase
    {
        public static int ConstructorId { get; } = -1279654347;
        public int Flags { get; set; }
        public InputPhotoBase Id { get; set; }
        public int? TtlSeconds { get; set; }

        [Flags]
        public enum FlagsEnum
        {
            TtlSeconds = 1 << 0
        }

        public override void UpdateFlags()
        {
            Flags = TtlSeconds == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            UpdateFlags();
            writer.Write(Flags);
            writer.Write(Id);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                writer.Write(TtlSeconds.Value);
            }
        }

        public override void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            Id = reader.Read<InputPhotoBase>();
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                TtlSeconds = reader.Read<int>();
            }
        }
    }
}