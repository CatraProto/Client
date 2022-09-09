using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class WebPageAttributeTheme : CatraProto.Client.TL.Schemas.CloudChats.WebPageAttributeBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Documents = 1 << 0,
            Settings = 1 << 1
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 1421174295; }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("documents")]
        public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase> Documents { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("settings")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.ThemeSettingsBase Settings { get; set; }


        public WebPageAttributeTheme()
        {
        }

        public override void UpdateFlags()
        {
            Flags = Documents == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
            Flags = Settings == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var checkdocuments = writer.WriteVector(Documents, false);
                if (checkdocuments.IsError)
                {
                    return checkdocuments;
                }
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                var checksettings = writer.WriteObject(Settings);
                if (checksettings.IsError)
                {
                    return checksettings;
                }
            }


            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryflags = reader.ReadInt32();
            if (tryflags.IsError)
            {
                return ReadResult<IObject>.Move(tryflags);
            }

            Flags = tryflags.Value;
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var trydocuments = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
                if (trydocuments.IsError)
                {
                    return ReadResult<IObject>.Move(trydocuments);
                }

                Documents = trydocuments.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                var trysettings = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.ThemeSettingsBase>();
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
            return "webPageAttributeTheme";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new WebPageAttributeTheme();
            newClonedObject.Flags = Flags;
            if (Documents is not null)
            {
                newClonedObject.Documents = new List<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase>();
                foreach (var documents in Documents)
                {
                    var clonedocuments = (CatraProto.Client.TL.Schemas.CloudChats.DocumentBase?)documents.Clone();
                    if (clonedocuments is null)
                    {
                        return null;
                    }

                    newClonedObject.Documents.Add(clonedocuments);
                }
            }

            if (Settings is not null)
            {
                var cloneSettings = (CatraProto.Client.TL.Schemas.CloudChats.ThemeSettingsBase?)Settings.Clone();
                if (cloneSettings is null)
                {
                    return null;
                }

                newClonedObject.Settings = cloneSettings;
            }

            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not WebPageAttributeTheme castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (Documents is null && castedOther.Documents is not null || Documents is not null && castedOther.Documents is null)
            {
                return true;
            }

            if (Documents is not null && castedOther.Documents is not null)
            {
                var documentssize = castedOther.Documents.Count;
                if (documentssize != Documents.Count)
                {
                    return true;
                }

                for (var i = 0; i < documentssize; i++)
                {
                    if (castedOther.Documents[i].Compare(Documents[i]))
                    {
                        return true;
                    }
                }
            }

            if (Settings is null && castedOther.Settings is not null || Settings is not null && castedOther.Settings is null)
            {
                return true;
            }

            if (Settings is not null && castedOther.Settings is not null && Settings.Compare(castedOther.Settings))
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}