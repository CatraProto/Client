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
namespace CatraProto.Client.TL.Schemas.CloudChats.Auth
{
    public partial class LoggedOut : CatraProto.Client.TL.Schemas.CloudChats.Auth.LoggedOutBase
    {
        [Flags]
        public enum FlagsEnum
        {
            FutureAuthToken = 1 << 0
        }

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1012759713; }

        [Newtonsoft.Json.JsonIgnore]
        public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("future_auth_token")]
        public sealed override byte[] FutureAuthToken { get; set; }



        public LoggedOut()
        {
        }

        public override void UpdateFlags()
        {
            Flags = FutureAuthToken == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {

                writer.WriteBytes(FutureAuthToken);
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
                var tryfutureAuthToken = reader.ReadBytes();
                if (tryfutureAuthToken.IsError)
                {
                    return ReadResult<IObject>.Move(tryfutureAuthToken);
                }
                FutureAuthToken = tryfutureAuthToken.Value;
            }

            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "auth.loggedOut";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new LoggedOut
            {
                Flags = Flags,
                FutureAuthToken = FutureAuthToken
            };
            return newClonedObject;

        }
#nullable disable
    }
}