/*
CatraProto, a C# library that implements the MTProto protocol and the Telegram API.
Copyright (C) 2022 Aquatica <aquathing@protonmail.com>

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Lesser General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Lesser General Public License for more details.

You should have received a copy of the GNU Lesser General Public License
along with this program.  If not, see <https://www.gnu.org/licenses/>.
*/

using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public partial class InstallWallPaper : IMethod
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -18000023; }

        [Newtonsoft.Json.JsonIgnore]
        ParserTypes IMethod.Type { get; init; } = ParserTypes.Bool;

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