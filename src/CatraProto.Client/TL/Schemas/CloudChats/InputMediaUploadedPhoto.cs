using System;
using System.Collections.Generic;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public class InputMediaUploadedPhoto : InputMediaBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Stickers = 1 << 0,
            TtlSeconds = 1 << 1
        }

        public static int ConstructorId { get; } = 505969924;
        public int Flags { get; set; }
        public InputFileBase File { get; set; }
        public IList<InputDocumentBase> Stickers { get; set; }
        public int? TtlSeconds { get; set; }

        public override void UpdateFlags()
        {
            Flags = Stickers == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
            Flags = TtlSeconds == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            UpdateFlags();
            writer.Write(Flags);
            writer.Write(File);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                writer.Write(Stickers);
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                writer.Write(TtlSeconds.Value);
            }
        }

        public override void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            File = reader.Read<InputFileBase>();
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                Stickers = reader.ReadVector<InputDocumentBase>();
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                TtlSeconds = reader.Read<int>();
            }
        }
    }
}