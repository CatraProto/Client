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

using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public partial class ContentSettings : CatraProto.Client.TL.Schemas.CloudChats.Account.ContentSettingsBase
    {
        [Flags]
        public enum FlagsEnum
        {
            SensitiveEnabled = 1 << 0,
            SensitiveCanChange = 1 << 1
        }

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1474462241; }

        [Newtonsoft.Json.JsonIgnore]
        public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("sensitive_enabled")]
        public sealed override bool SensitiveEnabled { get; set; }

        [Newtonsoft.Json.JsonProperty("sensitive_can_change")]
        public sealed override bool SensitiveCanChange { get; set; }



        public ContentSettings()
        {
        }

        public override void UpdateFlags()
        {
            Flags = SensitiveEnabled ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
            Flags = SensitiveCanChange ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);

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
            SensitiveEnabled = FlagsHelper.IsFlagSet(Flags, 0);
            SensitiveCanChange = FlagsHelper.IsFlagSet(Flags, 1);
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "account.contentSettings";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new ContentSettings
            {
                Flags = Flags,
                SensitiveEnabled = SensitiveEnabled,
                SensitiveCanChange = SensitiveCanChange
            };
            return newClonedObject;

        }

        public override bool Compare(IObject other)
        {
            if (other is not ContentSettings castedOther)
            {
                return true;
            }
            if (Flags != castedOther.Flags)
            {
                return true;
            }
            if (SensitiveEnabled != castedOther.SensitiveEnabled)
            {
                return true;
            }
            if (SensitiveCanChange != castedOther.SensitiveCanChange)
            {
                return true;
            }
            return false;

        }

#nullable disable
    }
}