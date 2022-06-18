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
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class ChatInviteImporter : CatraProto.Client.TL.Schemas.CloudChats.ChatInviteImporterBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Requested = 1 << 0,
            About = 1 << 2,
            ApprovedBy = 1 << 1
        }

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1940201511; }

        [Newtonsoft.Json.JsonIgnore]
        public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("requested")]
        public sealed override bool Requested { get; set; }

        [Newtonsoft.Json.JsonProperty("user_id")]
        public sealed override long UserId { get; set; }

        [Newtonsoft.Json.JsonProperty("date")]
        public sealed override int Date { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("about")]
        public sealed override string About { get; set; }

        [Newtonsoft.Json.JsonProperty("approved_by")]
        public sealed override long? ApprovedBy { get; set; }


#nullable enable
        public ChatInviteImporter(long userId, int date)
        {
            UserId = userId;
            Date = date;

        }
#nullable disable
        internal ChatInviteImporter()
        {
        }

        public override void UpdateFlags()
        {
            Flags = Requested ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
            Flags = About == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
            Flags = ApprovedBy == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            writer.WriteInt64(UserId);
            writer.WriteInt32(Date);
            if (FlagsHelper.IsFlagSet(Flags, 2))
            {

                writer.WriteString(About);
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                writer.WriteInt64(ApprovedBy.Value);
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
            Requested = FlagsHelper.IsFlagSet(Flags, 0);
            var tryuserId = reader.ReadInt64();
            if (tryuserId.IsError)
            {
                return ReadResult<IObject>.Move(tryuserId);
            }
            UserId = tryuserId.Value;
            var trydate = reader.ReadInt32();
            if (trydate.IsError)
            {
                return ReadResult<IObject>.Move(trydate);
            }
            Date = trydate.Value;
            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                var tryabout = reader.ReadString();
                if (tryabout.IsError)
                {
                    return ReadResult<IObject>.Move(tryabout);
                }
                About = tryabout.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                var tryapprovedBy = reader.ReadInt64();
                if (tryapprovedBy.IsError)
                {
                    return ReadResult<IObject>.Move(tryapprovedBy);
                }
                ApprovedBy = tryapprovedBy.Value;
            }

            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "chatInviteImporter";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new ChatInviteImporter
            {
                Flags = Flags,
                Requested = Requested,
                UserId = UserId,
                Date = Date,
                About = About,
                ApprovedBy = ApprovedBy
            };
            return newClonedObject;

        }

        public override bool Compare(IObject other)
        {
            if (other is not ChatInviteImporter castedOther)
            {
                return true;
            }
            if (Flags != castedOther.Flags)
            {
                return true;
            }
            if (Requested != castedOther.Requested)
            {
                return true;
            }
            if (UserId != castedOther.UserId)
            {
                return true;
            }
            if (Date != castedOther.Date)
            {
                return true;
            }
            if (About != castedOther.About)
            {
                return true;
            }
            if (ApprovedBy != castedOther.ApprovedBy)
            {
                return true;
            }
            return false;

        }

#nullable disable
    }
}