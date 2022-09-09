using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public partial class UpdateTheme : IMethod
    {
        [Flags]
        public enum FlagsEnum
        {
            Slug = 1 << 0,
            Title = 1 << 1,
            Document = 1 << 2,
            Settings = 1 << 3
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 737414348; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("format")]
        public string Format { get; set; }

        [Newtonsoft.Json.JsonProperty("theme")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputThemeBase Theme { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("slug")]
        public string Slug { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("title")]
        public string Title { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("document")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputDocumentBase Document { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("settings")]
        public List<CatraProto.Client.TL.Schemas.CloudChats.InputThemeSettingsBase> Settings { get; set; }


#nullable enable
        public UpdateTheme(string format, CatraProto.Client.TL.Schemas.CloudChats.InputThemeBase theme)
        {
            Format = format;
            Theme = theme;
        }
#nullable disable

        internal UpdateTheme()
        {
        }

        public void UpdateFlags()
        {
            Flags = Slug == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
            Flags = Title == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
            Flags = Document == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
            Flags = Settings == null ? FlagsHelper.UnsetFlag(Flags, 3) : FlagsHelper.SetFlag(Flags, 3);
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);

            writer.WriteString(Format);
            var checktheme = writer.WriteObject(Theme);
            if (checktheme.IsError)
            {
                return checktheme;
            }

            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                writer.WriteString(Slug);
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                writer.WriteString(Title);
            }

            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                var checkdocument = writer.WriteObject(Document);
                if (checkdocument.IsError)
                {
                    return checkdocument;
                }
            }

            if (FlagsHelper.IsFlagSet(Flags, 3))
            {
                var checksettings = writer.WriteVector(Settings, false);
                if (checksettings.IsError)
                {
                    return checksettings;
                }
            }


            return new WriteResult();
        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryflags = reader.ReadInt32();
            if (tryflags.IsError)
            {
                return ReadResult<IObject>.Move(tryflags);
            }

            Flags = tryflags.Value;
            var tryformat = reader.ReadString();
            if (tryformat.IsError)
            {
                return ReadResult<IObject>.Move(tryformat);
            }

            Format = tryformat.Value;
            var trytheme = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputThemeBase>();
            if (trytheme.IsError)
            {
                return ReadResult<IObject>.Move(trytheme);
            }

            Theme = trytheme.Value;
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var tryslug = reader.ReadString();
                if (tryslug.IsError)
                {
                    return ReadResult<IObject>.Move(tryslug);
                }

                Slug = tryslug.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                var trytitle = reader.ReadString();
                if (trytitle.IsError)
                {
                    return ReadResult<IObject>.Move(trytitle);
                }

                Title = trytitle.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                var trydocument = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputDocumentBase>();
                if (trydocument.IsError)
                {
                    return ReadResult<IObject>.Move(trydocument);
                }

                Document = trydocument.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 3))
            {
                var trysettings = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.InputThemeSettingsBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
                if (trysettings.IsError)
                {
                    return ReadResult<IObject>.Move(trysettings);
                }

                Settings = trysettings.Value;
            }

            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "account.updateTheme";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new UpdateTheme();
            newClonedObject.Flags = Flags;
            newClonedObject.Format = Format;
            var cloneTheme = (CatraProto.Client.TL.Schemas.CloudChats.InputThemeBase?)Theme.Clone();
            if (cloneTheme is null)
            {
                return null;
            }

            newClonedObject.Theme = cloneTheme;
            newClonedObject.Slug = Slug;
            newClonedObject.Title = Title;
            if (Document is not null)
            {
                var cloneDocument = (CatraProto.Client.TL.Schemas.CloudChats.InputDocumentBase?)Document.Clone();
                if (cloneDocument is null)
                {
                    return null;
                }

                newClonedObject.Document = cloneDocument;
            }

            if (Settings is not null)
            {
                newClonedObject.Settings = new List<CatraProto.Client.TL.Schemas.CloudChats.InputThemeSettingsBase>();
                foreach (var settings in Settings)
                {
                    var clonesettings = (CatraProto.Client.TL.Schemas.CloudChats.InputThemeSettingsBase?)settings.Clone();
                    if (clonesettings is null)
                    {
                        return null;
                    }

                    newClonedObject.Settings.Add(clonesettings);
                }
            }

            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not UpdateTheme castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (Format != castedOther.Format)
            {
                return true;
            }

            if (Theme.Compare(castedOther.Theme))
            {
                return true;
            }

            if (Slug != castedOther.Slug)
            {
                return true;
            }

            if (Title != castedOther.Title)
            {
                return true;
            }

            if (Document is null && castedOther.Document is not null || Document is not null && castedOther.Document is null)
            {
                return true;
            }

            if (Document is not null && castedOther.Document is not null && Document.Compare(castedOther.Document))
            {
                return true;
            }

            if (Settings is null && castedOther.Settings is not null || Settings is not null && castedOther.Settings is null)
            {
                return true;
            }

            if (Settings is not null && castedOther.Settings is not null)
            {
                var settingssize = castedOther.Settings.Count;
                if (settingssize != Settings.Count)
                {
                    return true;
                }

                for (var i = 0; i < settingssize; i++)
                {
                    if (castedOther.Settings[i].Compare(Settings[i]))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
#nullable disable
    }
}