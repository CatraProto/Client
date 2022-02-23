using System;
using System.Collections.Generic;
using CatraProto.TL;

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

        public static int StaticConstructorId
        {
            get => 1421174295;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("documents")]
        public sealed override IList<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase> Documents { get; set; }

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

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            UpdateFlags();
            writer.Write(Flags);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                writer.Write(Documents);
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                writer.Write(Settings);
            }
        }

        public override void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                Documents = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase>();
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                Settings = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.ThemeSettingsBase>();
            }
        }

        public override string ToString()
        {
            return "webPageAttributeTheme";
        }
    }
}