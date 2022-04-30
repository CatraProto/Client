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
    public partial class ChatInviteExported : CatraProto.Client.TL.Schemas.CloudChats.ExportedChatInviteBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Revoked = 1 << 0,
            Permanent = 1 << 5,
            RequestNeeded = 1 << 6,
            StartDate = 1 << 4,
            ExpireDate = 1 << 1,
            UsageLimit = 1 << 2,
            Usage = 1 << 3,
            Requested = 1 << 7,
            Title = 1 << 8
        }

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 179611673; }

        [Newtonsoft.Json.JsonIgnore]
        public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("revoked")]
        public sealed override bool Revoked { get; set; }

        [Newtonsoft.Json.JsonProperty("permanent")]
        public sealed override bool Permanent { get; set; }

        [Newtonsoft.Json.JsonProperty("request_needed")]
        public sealed override bool RequestNeeded { get; set; }

        [Newtonsoft.Json.JsonProperty("link")]
        public sealed override string Link { get; set; }

        [Newtonsoft.Json.JsonProperty("admin_id")]
        public sealed override long AdminId { get; set; }

        [Newtonsoft.Json.JsonProperty("date")]
        public sealed override int Date { get; set; }

        [Newtonsoft.Json.JsonProperty("start_date")]
        public sealed override int? StartDate { get; set; }

        [Newtonsoft.Json.JsonProperty("expire_date")]
        public sealed override int? ExpireDate { get; set; }

        [Newtonsoft.Json.JsonProperty("usage_limit")]
        public sealed override int? UsageLimit { get; set; }

        [Newtonsoft.Json.JsonProperty("usage")]
        public sealed override int? Usage { get; set; }

        [Newtonsoft.Json.JsonProperty("requested")]
        public sealed override int? Requested { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("title")]
        public sealed override string Title { get; set; }


#nullable enable
        public ChatInviteExported(string link, long adminId, int date)
        {
            Link = link;
            AdminId = adminId;
            Date = date;

        }
#nullable disable
        internal ChatInviteExported()
        {
        }

        public override void UpdateFlags()
        {
            Flags = Revoked ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
            Flags = Permanent ? FlagsHelper.SetFlag(Flags, 5) : FlagsHelper.UnsetFlag(Flags, 5);
            Flags = RequestNeeded ? FlagsHelper.SetFlag(Flags, 6) : FlagsHelper.UnsetFlag(Flags, 6);
            Flags = StartDate == null ? FlagsHelper.UnsetFlag(Flags, 4) : FlagsHelper.SetFlag(Flags, 4);
            Flags = ExpireDate == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
            Flags = UsageLimit == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
            Flags = Usage == null ? FlagsHelper.UnsetFlag(Flags, 3) : FlagsHelper.SetFlag(Flags, 3);
            Flags = Requested == null ? FlagsHelper.UnsetFlag(Flags, 7) : FlagsHelper.SetFlag(Flags, 7);
            Flags = Title == null ? FlagsHelper.UnsetFlag(Flags, 8) : FlagsHelper.SetFlag(Flags, 8);

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);

            writer.WriteString(Link);
            writer.WriteInt64(AdminId);
            writer.WriteInt32(Date);
            if (FlagsHelper.IsFlagSet(Flags, 4))
            {
                writer.WriteInt32(StartDate.Value);
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                writer.WriteInt32(ExpireDate.Value);
            }

            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                writer.WriteInt32(UsageLimit.Value);
            }

            if (FlagsHelper.IsFlagSet(Flags, 3))
            {
                writer.WriteInt32(Usage.Value);
            }

            if (FlagsHelper.IsFlagSet(Flags, 7))
            {
                writer.WriteInt32(Requested.Value);
            }

            if (FlagsHelper.IsFlagSet(Flags, 8))
            {

                writer.WriteString(Title);
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
            Revoked = FlagsHelper.IsFlagSet(Flags, 0);
            Permanent = FlagsHelper.IsFlagSet(Flags, 5);
            RequestNeeded = FlagsHelper.IsFlagSet(Flags, 6);
            var trylink = reader.ReadString();
            if (trylink.IsError)
            {
                return ReadResult<IObject>.Move(trylink);
            }
            Link = trylink.Value;
            var tryadminId = reader.ReadInt64();
            if (tryadminId.IsError)
            {
                return ReadResult<IObject>.Move(tryadminId);
            }
            AdminId = tryadminId.Value;
            var trydate = reader.ReadInt32();
            if (trydate.IsError)
            {
                return ReadResult<IObject>.Move(trydate);
            }
            Date = trydate.Value;
            if (FlagsHelper.IsFlagSet(Flags, 4))
            {
                var trystartDate = reader.ReadInt32();
                if (trystartDate.IsError)
                {
                    return ReadResult<IObject>.Move(trystartDate);
                }
                StartDate = trystartDate.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                var tryexpireDate = reader.ReadInt32();
                if (tryexpireDate.IsError)
                {
                    return ReadResult<IObject>.Move(tryexpireDate);
                }
                ExpireDate = tryexpireDate.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                var tryusageLimit = reader.ReadInt32();
                if (tryusageLimit.IsError)
                {
                    return ReadResult<IObject>.Move(tryusageLimit);
                }
                UsageLimit = tryusageLimit.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 3))
            {
                var tryusage = reader.ReadInt32();
                if (tryusage.IsError)
                {
                    return ReadResult<IObject>.Move(tryusage);
                }
                Usage = tryusage.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 7))
            {
                var tryrequested = reader.ReadInt32();
                if (tryrequested.IsError)
                {
                    return ReadResult<IObject>.Move(tryrequested);
                }
                Requested = tryrequested.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 8))
            {
                var trytitle = reader.ReadString();
                if (trytitle.IsError)
                {
                    return ReadResult<IObject>.Move(trytitle);
                }
                Title = trytitle.Value;
            }

            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "chatInviteExported";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new ChatInviteExported
            {
                Flags = Flags,
                Revoked = Revoked,
                Permanent = Permanent,
                RequestNeeded = RequestNeeded,
                Link = Link,
                AdminId = AdminId,
                Date = Date,
                StartDate = StartDate,
                ExpireDate = ExpireDate,
                UsageLimit = UsageLimit,
                Usage = Usage,
                Requested = Requested,
                Title = Title
            };
            return newClonedObject;

        }
#nullable disable
    }
}