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
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public partial class RegisterDevice : IMethod
    {
        [Flags]
        public enum FlagsEnum
        {
            NoMuted = 1 << 0
        }

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -326762118; }

        [Newtonsoft.Json.JsonIgnore]
        ParserTypes IMethod.Type { get; init; } = ParserTypes.Bool;

        [Newtonsoft.Json.JsonIgnore]
        public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("no_muted")]
        public bool NoMuted { get; set; }

        [Newtonsoft.Json.JsonProperty("token_type")]
        public int TokenType { get; set; }

        [Newtonsoft.Json.JsonProperty("token")]
        public string Token { get; set; }

        [Newtonsoft.Json.JsonProperty("app_sandbox")]
        public bool AppSandbox { get; set; }

        [Newtonsoft.Json.JsonProperty("secret")]
        public byte[] Secret { get; set; }

        [Newtonsoft.Json.JsonProperty("other_uids")]
        public List<long> OtherUids { get; set; }


#nullable enable
        public RegisterDevice(int tokenType, string token, bool appSandbox, byte[] secret, List<long> otherUids)
        {
            TokenType = tokenType;
            Token = token;
            AppSandbox = appSandbox;
            Secret = secret;
            OtherUids = otherUids;

        }
#nullable disable

        internal RegisterDevice()
        {
        }

        public void UpdateFlags()
        {
            Flags = NoMuted ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);

        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            writer.WriteInt32(TokenType);

            writer.WriteString(Token);
            var checkappSandbox = writer.WriteBool(AppSandbox);
            if (checkappSandbox.IsError)
            {
                return checkappSandbox;
            }

            writer.WriteBytes(Secret);

            writer.WriteVector(OtherUids, false);

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
            NoMuted = FlagsHelper.IsFlagSet(Flags, 0);
            var trytokenType = reader.ReadInt32();
            if (trytokenType.IsError)
            {
                return ReadResult<IObject>.Move(trytokenType);
            }
            TokenType = trytokenType.Value;
            var trytoken = reader.ReadString();
            if (trytoken.IsError)
            {
                return ReadResult<IObject>.Move(trytoken);
            }
            Token = trytoken.Value;
            var tryappSandbox = reader.ReadBool();
            if (tryappSandbox.IsError)
            {
                return ReadResult<IObject>.Move(tryappSandbox);
            }
            AppSandbox = tryappSandbox.Value;
            var trysecret = reader.ReadBytes();
            if (trysecret.IsError)
            {
                return ReadResult<IObject>.Move(trysecret);
            }
            Secret = trysecret.Value;
            var tryotherUids = reader.ReadVector<long>(ParserTypes.Int64);
            if (tryotherUids.IsError)
            {
                return ReadResult<IObject>.Move(tryotherUids);
            }
            OtherUids = tryotherUids.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "account.registerDevice";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new RegisterDevice
            {
                Flags = Flags,
                NoMuted = NoMuted,
                TokenType = TokenType,
                Token = Token,
                AppSandbox = AppSandbox,
                Secret = Secret
            };
            foreach (var otherUids in OtherUids)
            {
                newClonedObject.OtherUids.Add(otherUids);
            }
            return newClonedObject;

        }
#nullable disable
    }
}