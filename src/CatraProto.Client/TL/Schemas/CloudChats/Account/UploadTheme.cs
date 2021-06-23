using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public class UploadTheme : IMethod
    {
        [Flags]
        public enum FlagsEnum
        {
            Thumb = 1 << 0
        }

        public static int ConstructorId { get; } = 473805619;

        public Type Type { get; init; } = typeof(DocumentBase);
        public bool IsVector { get; init; } = false;
        public int Flags { get; set; }
        public InputFileBase File { get; set; }
        public InputFileBase Thumb { get; set; }
        public string FileName { get; set; }
        public string MimeType { get; set; }

        public void UpdateFlags()
        {
            Flags = Thumb == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
        }

        public void Serialize(Writer writer)
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
                writer.Write(Thumb);
            }

            writer.Write(FileName);
            writer.Write(MimeType);
        }

        public void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            File = reader.Read<InputFileBase>();
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                Thumb = reader.Read<InputFileBase>();
            }

            FileName = reader.Read<string>();
            MimeType = reader.Read<string>();
        }
    }
}