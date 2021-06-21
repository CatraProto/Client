using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public partial class UploadWallPaper : IMethod
    {
        public static int ConstructorId { get; } = -578472351;
        public InputFileBase File { get; set; }
        public string MimeType { get; set; }
        public WallPaperSettingsBase Settings { get; set; }

        public Type Type { get; init; } = typeof(WallPaperBase);
        public bool IsVector { get; init; } = false;

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            writer.Write(File);
            writer.Write(MimeType);
            writer.Write(Settings);
        }

        public void Deserialize(Reader reader)
        {
            File = reader.Read<InputFileBase>();
            MimeType = reader.Read<string>();
            Settings = reader.Read<WallPaperSettingsBase>();
        }
    }
}