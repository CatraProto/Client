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
    public partial class InstallWallPaper : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -18000023; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Bool;

        [Newtonsoft.Json.JsonProperty("wallpaper")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputWallPaperBase Wallpaper { get; set; }

        [Newtonsoft.Json.JsonProperty("settings")]
        public CatraProto.Client.TL.Schemas.CloudChats.WallPaperSettingsBase Settings { get; set; }


#nullable enable
        public InstallWallPaper(CatraProto.Client.TL.Schemas.CloudChats.InputWallPaperBase wallpaper, CatraProto.Client.TL.Schemas.CloudChats.WallPaperSettingsBase settings)
        {
            Wallpaper = wallpaper;
            Settings = settings;
        }
#nullable disable

        internal InstallWallPaper()
        {
        }

        public void UpdateFlags()
        {
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkwallpaper = writer.WriteObject(Wallpaper);
            if (checkwallpaper.IsError)
            {
                return checkwallpaper;
            }

            var checksettings = writer.WriteObject(Settings);
            if (checksettings.IsError)
            {
                return checksettings;
            }

            return new WriteResult();
        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var trywallpaper = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputWallPaperBase>();
            if (trywallpaper.IsError)
            {
                return ReadResult<IObject>.Move(trywallpaper);
            }

            Wallpaper = trywallpaper.Value;
            var trysettings = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.WallPaperSettingsBase>();
            if (trysettings.IsError)
            {
                return ReadResult<IObject>.Move(trysettings);
            }

            Settings = trysettings.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "account.installWallPaper";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new InstallWallPaper();
            var cloneWallpaper = (CatraProto.Client.TL.Schemas.CloudChats.InputWallPaperBase?)Wallpaper.Clone();
            if (cloneWallpaper is null)
            {
                return null;
            }

            newClonedObject.Wallpaper = cloneWallpaper;
            var cloneSettings = (CatraProto.Client.TL.Schemas.CloudChats.WallPaperSettingsBase?)Settings.Clone();
            if (cloneSettings is null)
            {
                return null;
            }

            newClonedObject.Settings = cloneSettings;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not InstallWallPaper castedOther)
            {
                return true;
            }

            if (Wallpaper.Compare(castedOther.Wallpaper))
            {
                return true;
            }

            if (Settings.Compare(castedOther.Settings))
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}