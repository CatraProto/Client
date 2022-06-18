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
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class UpdateReadChannelInbox : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
    {
        [Flags]
        public enum FlagsEnum
        {
            FolderId = 1 << 0
        }

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1842450928; }

        [Newtonsoft.Json.JsonIgnore]
        public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("folder_id")]
        public int? FolderId { get; set; }

        [Newtonsoft.Json.JsonProperty("channel_id")]
        public long ChannelId { get; set; }

        [Newtonsoft.Json.JsonProperty("max_id")]
        public int MaxId { get; set; }

        [Newtonsoft.Json.JsonProperty("still_unread_count")]
        public int StillUnreadCount { get; set; }

        [Newtonsoft.Json.JsonProperty("pts")]
        public int Pts { get; set; }


#nullable enable
        public UpdateReadChannelInbox(long channelId, int maxId, int stillUnreadCount, int pts)
        {
            ChannelId = channelId;
            MaxId = maxId;
            StillUnreadCount = stillUnreadCount;
            Pts = pts;

        }
#nullable disable
        internal UpdateReadChannelInbox()
        {
        }

        public override void UpdateFlags()
        {
            Flags = FolderId == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                writer.WriteInt32(FolderId.Value);
            }

            writer.WriteInt64(ChannelId);
            writer.WriteInt32(MaxId);
            writer.WriteInt32(StillUnreadCount);
            writer.WriteInt32(Pts);

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
                var tryfolderId = reader.ReadInt32();
                if (tryfolderId.IsError)
                {
                    return ReadResult<IObject>.Move(tryfolderId);
                }
                FolderId = tryfolderId.Value;
            }

            var trychannelId = reader.ReadInt64();
            if (trychannelId.IsError)
            {
                return ReadResult<IObject>.Move(trychannelId);
            }
            ChannelId = trychannelId.Value;
            var trymaxId = reader.ReadInt32();
            if (trymaxId.IsError)
            {
                return ReadResult<IObject>.Move(trymaxId);
            }
            MaxId = trymaxId.Value;
            var trystillUnreadCount = reader.ReadInt32();
            if (trystillUnreadCount.IsError)
            {
                return ReadResult<IObject>.Move(trystillUnreadCount);
            }
            StillUnreadCount = trystillUnreadCount.Value;
            var trypts = reader.ReadInt32();
            if (trypts.IsError)
            {
                return ReadResult<IObject>.Move(trypts);
            }
            Pts = trypts.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "updateReadChannelInbox";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new UpdateReadChannelInbox
            {
                Flags = Flags,
                FolderId = FolderId,
                ChannelId = ChannelId,
                MaxId = MaxId,
                StillUnreadCount = StillUnreadCount,
                Pts = Pts
            };
            return newClonedObject;

        }

        public override bool Compare(IObject other)
        {
            if (other is not UpdateReadChannelInbox castedOther)
            {
                return true;
            }
            if (Flags != castedOther.Flags)
            {
                return true;
            }
            if (FolderId != castedOther.FolderId)
            {
                return true;
            }
            if (ChannelId != castedOther.ChannelId)
            {
                return true;
            }
            if (MaxId != castedOther.MaxId)
            {
                return true;
            }
            if (StillUnreadCount != castedOther.StillUnreadCount)
            {
                return true;
            }
            if (Pts != castedOther.Pts)
            {
                return true;
            }
            return false;

        }

#nullable disable
    }
}