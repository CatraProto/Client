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

namespace CatraProto.Client.TL.Schemas.CloudChats.Auth
{
    public partial class RecoverPassword : IMethod
    {
        [Flags]
        public enum FlagsEnum
        {
            NewSettings = 1 << 0
        }

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 923364464; }

        [Newtonsoft.Json.JsonIgnore]
        ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonIgnore]
        public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("code")]
        public string Code { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("new_settings")]
        public CatraProto.Client.TL.Schemas.CloudChats.Account.PasswordInputSettingsBase NewSettings { get; set; }


#nullable enable
        public RecoverPassword(string code)
        {
            Code = code;

        }
#nullable disable

        internal RecoverPassword()
        {
        }

        public void UpdateFlags()
        {
            Flags = NewSettings == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);

        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);

            writer.WriteString(Code);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var checknewSettings = writer.WriteObject(NewSettings);
                if (checknewSettings.IsError)
                {
                    return checknewSettings;
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
            var trycode = reader.ReadString();
            if (trycode.IsError)
            {
                return ReadResult<IObject>.Move(trycode);
            }
            Code = trycode.Value;
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var trynewSettings = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.Account.PasswordInputSettingsBase>();
                if (trynewSettings.IsError)
                {
                    return ReadResult<IObject>.Move(trynewSettings);
                }
                NewSettings = trynewSettings.Value;
            }

            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "auth.recoverPassword";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new RecoverPassword
            {
                Flags = Flags,
                Code = Code
            };
            if (NewSettings is not null)
            {
                var cloneNewSettings = (CatraProto.Client.TL.Schemas.CloudChats.Account.PasswordInputSettingsBase?)NewSettings.Clone();
                if (cloneNewSettings is null)
                {
                    return null;
                }
                newClonedObject.NewSettings = cloneNewSettings;
            }
            return newClonedObject;

        }
#nullable disable
    }
}