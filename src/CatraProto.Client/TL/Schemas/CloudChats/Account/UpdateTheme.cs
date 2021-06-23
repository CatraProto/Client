using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public class UpdateTheme : IMethod
    {
        [Flags]
        public enum FlagsEnum
        {
            Slug = 1 << 0,
            Title = 1 << 1,
            Document = 1 << 2,
            Settings = 1 << 3
        }

        public static int ConstructorId { get; } = 1555261397;

        public Type Type { get; init; } = typeof(ThemeBase);
        public bool IsVector { get; init; } = false;
        public int Flags { get; set; }
        public string Format { get; set; }
        public InputThemeBase Theme { get; set; }
        public string Slug { get; set; }
        public string Title { get; set; }
        public InputDocumentBase Document { get; set; }
        public InputThemeSettingsBase Settings { get; set; }

        public void UpdateFlags()
        {
            Flags = Slug == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
            Flags = Title == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
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
            writer.Write(Format);
            writer.Write(Theme);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                writer.Write(Slug);
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                writer.Write(Title);
            }

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
            Format = reader.Read<string>();
            Theme = reader.Read<InputThemeBase>();
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                Slug = reader.Read<string>();
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                Title = reader.Read<string>();
            }

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