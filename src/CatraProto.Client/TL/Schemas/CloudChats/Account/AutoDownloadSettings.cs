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
    public partial class AutoDownloadSettings : CatraProto.Client.TL.Schemas.CloudChats.Account.AutoDownloadSettingsBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1674235686; }

        [Newtonsoft.Json.JsonProperty("low")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.AutoDownloadSettingsBase Low { get; set; }

        [Newtonsoft.Json.JsonProperty("medium")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.AutoDownloadSettingsBase Medium { get; set; }

        [Newtonsoft.Json.JsonProperty("high")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.AutoDownloadSettingsBase High { get; set; }


#nullable enable
        public AutoDownloadSettings(CatraProto.Client.TL.Schemas.CloudChats.AutoDownloadSettingsBase low, CatraProto.Client.TL.Schemas.CloudChats.AutoDownloadSettingsBase medium, CatraProto.Client.TL.Schemas.CloudChats.AutoDownloadSettingsBase high)
        {
            Low = low;
            Medium = medium;
            High = high;

        }
#nullable disable
        internal AutoDownloadSettings()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checklow = writer.WriteObject(Low);
            if (checklow.IsError)
            {
                return checklow;
            }
            var checkmedium = writer.WriteObject(Medium);
            if (checkmedium.IsError)
            {
                return checkmedium;
            }
            var checkhigh = writer.WriteObject(High);
            if (checkhigh.IsError)
            {
                return checkhigh;
            }

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trylow = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.AutoDownloadSettingsBase>();
            if (trylow.IsError)
            {
                return ReadResult<IObject>.Move(trylow);
            }
            Low = trylow.Value;
            var trymedium = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.AutoDownloadSettingsBase>();
            if (trymedium.IsError)
            {
                return ReadResult<IObject>.Move(trymedium);
            }
            Medium = trymedium.Value;
            var tryhigh = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.AutoDownloadSettingsBase>();
            if (tryhigh.IsError)
            {
                return ReadResult<IObject>.Move(tryhigh);
            }
            High = tryhigh.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "account.autoDownloadSettings";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new AutoDownloadSettings();
            var cloneLow = (CatraProto.Client.TL.Schemas.CloudChats.AutoDownloadSettingsBase?)Low.Clone();
            if (cloneLow is null)
            {
                return null;
            }
            newClonedObject.Low = cloneLow;
            var cloneMedium = (CatraProto.Client.TL.Schemas.CloudChats.AutoDownloadSettingsBase?)Medium.Clone();
            if (cloneMedium is null)
            {
                return null;
            }
            newClonedObject.Medium = cloneMedium;
            var cloneHigh = (CatraProto.Client.TL.Schemas.CloudChats.AutoDownloadSettingsBase?)High.Clone();
            if (cloneHigh is null)
            {
                return null;
            }
            newClonedObject.High = cloneHigh;
            return newClonedObject;

        }
#nullable disable
    }
}