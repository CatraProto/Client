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
    public partial class ChangeAuthorizationSettings : IMethod
    {
        [Flags]
        public enum FlagsEnum
        {
            EncryptedRequestsDisabled = 1 << 0,
            CallRequestsDisabled = 1 << 1
        }

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1089766498; }

        [Newtonsoft.Json.JsonIgnore]
        ParserTypes IMethod.Type { get; init; } = ParserTypes.Bool;

        [Newtonsoft.Json.JsonIgnore]
        public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("hash")]
        public long Hash { get; set; }

        [Newtonsoft.Json.JsonProperty("encrypted_requests_disabled")]
        public bool? EncryptedRequestsDisabled { get; set; }

        [Newtonsoft.Json.JsonProperty("call_requests_disabled")]
        public bool? CallRequestsDisabled { get; set; }


#nullable enable
        public ChangeAuthorizationSettings(long hash)
        {
            Hash = hash;

        }
#nullable disable

        internal ChangeAuthorizationSettings()
        {
        }

        public void UpdateFlags()
        {
            Flags = EncryptedRequestsDisabled == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
            Flags = CallRequestsDisabled == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);

        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            writer.WriteInt64(Hash);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var checkencryptedRequestsDisabled = writer.WriteBool(EncryptedRequestsDisabled.Value);
                if (checkencryptedRequestsDisabled.IsError)
                {
                    return checkencryptedRequestsDisabled;
                }
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                var checkcallRequestsDisabled = writer.WriteBool(CallRequestsDisabled.Value);
                if (checkcallRequestsDisabled.IsError)
                {
                    return checkcallRequestsDisabled;
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
            var tryhash = reader.ReadInt64();
            if (tryhash.IsError)
            {
                return ReadResult<IObject>.Move(tryhash);
            }
            Hash = tryhash.Value;
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var tryencryptedRequestsDisabled = reader.ReadBool();
                if (tryencryptedRequestsDisabled.IsError)
                {
                    return ReadResult<IObject>.Move(tryencryptedRequestsDisabled);
                }
                EncryptedRequestsDisabled = tryencryptedRequestsDisabled.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                var trycallRequestsDisabled = reader.ReadBool();
                if (trycallRequestsDisabled.IsError)
                {
                    return ReadResult<IObject>.Move(trycallRequestsDisabled);
                }
                CallRequestsDisabled = trycallRequestsDisabled.Value;
            }

            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "account.changeAuthorizationSettings";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new ChangeAuthorizationSettings
            {
                Flags = Flags,
                Hash = Hash,
                EncryptedRequestsDisabled = EncryptedRequestsDisabled,
                CallRequestsDisabled = CallRequestsDisabled
            };
            return newClonedObject;

        }
#nullable disable
    }
}