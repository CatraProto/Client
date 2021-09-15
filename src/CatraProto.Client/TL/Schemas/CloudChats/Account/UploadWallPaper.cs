using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public partial class UploadWallPaper : IMethod
    {
        [JsonIgnore]
        public static int StaticConstructorId
        {
            get => -578472351;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(WallPaperBase);

        [JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [JsonProperty("file")] public InputFileBase File { get; set; }

        [JsonProperty("mime_type")] public string MimeType { get; set; }

        [JsonProperty("settings")] public WallPaperSettingsBase Settings { get; set; }

        public override string ToString()
        {
            return "account.uploadWallPaper";
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