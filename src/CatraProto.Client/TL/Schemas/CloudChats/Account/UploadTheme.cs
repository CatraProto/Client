using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public partial class UploadTheme : IMethod
    {
        [Flags]
        public enum FlagsEnum
        {
            Thumb = 1 << 0
        }

        [JsonIgnore]
        public static int StaticConstructorId
        {
            get => 473805619;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(DocumentBase);

        [JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [JsonIgnore] public int Flags { get; set; }

        [JsonProperty("file")] public InputFileBase File { get; set; }

        [JsonProperty("thumb")] public InputFileBase Thumb { get; set; }

        [JsonProperty("file_name")] public string FileName { get; set; }

        [JsonProperty("mime_type")] public string MimeType { get; set; }

        public override string ToString()
        {
            return "account.uploadTheme";
        }


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