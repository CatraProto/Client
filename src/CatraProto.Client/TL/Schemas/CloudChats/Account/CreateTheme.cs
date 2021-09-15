using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public partial class CreateTheme : IMethod
    {
        [Flags]
        public enum FlagsEnum
        {
            Document = 1 << 2,
            Settings = 1 << 3
        }

        [JsonIgnore]
        public static int StaticConstructorId
        {
            get => -2077048289;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(ThemeBase);

        [JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [JsonIgnore] public int Flags { get; set; }

        [JsonProperty("slug")] public string Slug { get; set; }

        [JsonProperty("title")] public string Title { get; set; }

        [JsonProperty("document")] public InputDocumentBase Document { get; set; }

        [JsonProperty("settings")] public InputThemeSettingsBase Settings { get; set; }

        public override string ToString()
        {
            return "account.createTheme";
        }


        public void UpdateFlags()
        {
            Flags = Document == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
            Flags = Settings == null ? FlagsHelper.UnsetFlag(Flags, 3) : FlagsHelper.SetFlag(Flags, 3);
        }

        public void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            UpdateFlags();
            writer.Write(Flags);
            writer.Write(Slug);
            writer.Write(Title);
            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                writer.Write(Document);
            }

            if (FlagsHelper.IsFlagSet(Flags, 3))
            {
                writer.Write(Settings);
            }
        }

        public void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            Slug = reader.Read<string>();
            Title = reader.Read<string>();
            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                Document = reader.Read<InputDocumentBase>();
            }

            if (FlagsHelper.IsFlagSet(Flags, 3))
            {
                Settings = reader.Read<InputThemeSettingsBase>();
            }
        }
    }
}