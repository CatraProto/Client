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

namespace CatraProto.Client.TL.Schemas.CloudChats.Channels
{
    public partial class GetAdminedPublicChannels : IMethod
    {
        [Flags]
        public enum FlagsEnum
        {
            ByLocation = 1 << 0,
            CheckLimit = 1 << 1
        }

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -122669393; }

        [Newtonsoft.Json.JsonIgnore]
        ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonIgnore]
        public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("by_location")]
        public bool ByLocation { get; set; }

        [Newtonsoft.Json.JsonProperty("check_limit")]
        public bool CheckLimit { get; set; }




        public GetAdminedPublicChannels()
        {
        }

        public void UpdateFlags()
        {
            Flags = ByLocation ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
            Flags = CheckLimit ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);

        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);

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
            ByLocation = FlagsHelper.IsFlagSet(Flags, 0);
            CheckLimit = FlagsHelper.IsFlagSet(Flags, 1);
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "channels.getAdminedPublicChannels";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new GetAdminedPublicChannels
            {
                Flags = Flags,
                ByLocation = ByLocation,
                CheckLimit = CheckLimit
            };
            return newClonedObject;

        }

        public bool Compare(IObject other)
        {
            if (other is not GetAdminedPublicChannels castedOther)
            {
                return true;
            }
            if (Flags != castedOther.Flags)
            {
                return true;
            }
            if (ByLocation != castedOther.ByLocation)
            {
                return true;
            }
            if (CheckLimit != castedOther.CheckLimit)
            {
                return true;
            }
            return false;

        }
#nullable disable
    }
}