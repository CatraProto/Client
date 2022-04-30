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
using System.Diagnostics.CodeAnalysis;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Payments
{
    public partial class SavedInfo : CatraProto.Client.TL.Schemas.CloudChats.Payments.SavedInfoBase
    {
        [Flags]
        public enum FlagsEnum
        {
            HasSavedCredentials = 1 << 1,
            SavedInfoField = 1 << 0
        }

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -74456004; }

        [Newtonsoft.Json.JsonIgnore]
        public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("has_saved_credentials")]
        public sealed override bool HasSavedCredentials { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("saved_info")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.PaymentRequestedInfoBase SavedInfoField { get; set; }



        public SavedInfo()
        {
        }

        public override void UpdateFlags()
        {
            Flags = HasSavedCredentials ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
            Flags = SavedInfoField == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var checksavedInfoField = writer.WriteObject(SavedInfoField);
                if (checksavedInfoField.IsError)
                {
                    return checksavedInfoField;
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
            HasSavedCredentials = FlagsHelper.IsFlagSet(Flags, 1);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var trysavedInfoField = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.PaymentRequestedInfoBase>();
                if (trysavedInfoField.IsError)
                {
                    return ReadResult<IObject>.Move(trysavedInfoField);
                }
                SavedInfoField = trysavedInfoField.Value;
            }

            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "payments.savedInfo";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new SavedInfo
            {
                Flags = Flags,
                HasSavedCredentials = HasSavedCredentials
            };
            if (SavedInfoField is not null)
            {
                var cloneSavedInfoField = (CatraProto.Client.TL.Schemas.CloudChats.PaymentRequestedInfoBase?)SavedInfoField.Clone();
                if (cloneSavedInfoField is null)
                {
                    return null;
                }
                newClonedObject.SavedInfoField = cloneSavedInfoField;
            }
            return newClonedObject;

        }
#nullable disable
    }
}