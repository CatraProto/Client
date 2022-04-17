using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

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

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1421174295; }

        [Newtonsoft.Json.JsonIgnore]
        public int Flags { get; set; }

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
    }
}