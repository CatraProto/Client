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
namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public partial class PasswordSettings : CatraProto.Client.TL.Schemas.CloudChats.Account.PasswordSettingsBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Email = 1 << 0,
            SecureSettings = 1 << 1
        }

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1705233435; }

        [Newtonsoft.Json.JsonIgnore]
        public int Flags { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("email")]
        public sealed override string Email { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("secure_settings")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.SecureSecretSettingsBase SecureSettings { get; set; }



        public PasswordSettings()
        {
        }

        public override void UpdateFlags()
        {
            Flags = Email == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
            Flags = SecureSettings == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {

                writer.WriteString(Email);
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                var checksecureSettings = writer.WriteObject(SecureSettings);
                if (checksecureSettings.IsError)
                {
                    return checksecureSettings;
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
                var tryemail = reader.ReadString();
                if (tryemail.IsError)
                {
                    return ReadResult<IObject>.Move(tryemail);
                }
                Email = tryemail.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                var trysecureSettings = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.SecureSecretSettingsBase>();
                if (trysecureSettings.IsError)
                {
                    return ReadResult<IObject>.Move(trysecureSettings);
                }
                SecureSettings = trysecureSettings.Value;
            }

            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "account.passwordSettings";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new PasswordSettings
            {
                Flags = Flags,
                Email = Email
            };
            if (SecureSettings is not null)
            {
                var cloneSecureSettings = (CatraProto.Client.TL.Schemas.CloudChats.SecureSecretSettingsBase?)SecureSettings.Clone();
                if (cloneSecureSettings is null)
                {
                    return null;
                }
                newClonedObject.SecureSettings = cloneSecureSettings;
            }
            return newClonedObject;

        }
#nullable disable
    }
}