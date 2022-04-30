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
    public partial class UpdateProfile : IMethod
    {
        [Flags]
        public enum FlagsEnum
        {
            FirstName = 1 << 0,
            LastName = 1 << 1,
            About = 1 << 2
        }

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 2018596725; }

        [Newtonsoft.Json.JsonIgnore]
        ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonIgnore]
        public int Flags { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("first_name")]
        public string FirstName { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("last_name")]
        public string LastName { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("about")]
        public string About { get; set; }




        public UpdateProfile()
        {
        }

        public void UpdateFlags()
        {
            Flags = FirstName == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
            Flags = LastName == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
            Flags = About == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);

        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {

                writer.WriteString(FirstName);
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {

                writer.WriteString(LastName);
            }

            if (FlagsHelper.IsFlagSet(Flags, 2))
            {

                writer.WriteString(About);
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
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var tryfirstName = reader.ReadString();
                if (tryfirstName.IsError)
                {
                    return ReadResult<IObject>.Move(tryfirstName);
                }
                FirstName = tryfirstName.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                var trylastName = reader.ReadString();
                if (trylastName.IsError)
                {
                    return ReadResult<IObject>.Move(trylastName);
                }
                LastName = trylastName.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                var tryabout = reader.ReadString();
                if (tryabout.IsError)
                {
                    return ReadResult<IObject>.Move(tryabout);
                }
                About = tryabout.Value;
            }

            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "account.updateProfile";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new UpdateProfile
            {
                Flags = Flags,
                FirstName = FirstName,
                LastName = LastName,
                About = About
            };
            return newClonedObject;

        }
#nullable disable
    }
}