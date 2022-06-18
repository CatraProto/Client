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
    public partial class UpdateReadChannelDiscussionInbox : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
    {
        [Flags]
        public enum FlagsEnum
        {
            BroadcastId = 1 << 0,
            BroadcastPost = 1 << 0
        }

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -693004986; }

        [Newtonsoft.Json.JsonIgnore]
        public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("channel_id")]
        public long ChannelId { get; set; }

        [Newtonsoft.Json.JsonProperty("top_msg_id")]
        public int TopMsgId { get; set; }

        [Newtonsoft.Json.JsonProperty("read_max_id")]
        public int ReadMaxId { get; set; }

        [Newtonsoft.Json.JsonProperty("broadcast_id")]
        public long? BroadcastId { get; set; }

        [Newtonsoft.Json.JsonProperty("broadcast_post")]
        public int? BroadcastPost { get; set; }


#nullable enable
        public UpdateReadChannelDiscussionInbox(long channelId, int topMsgId, int readMaxId)
        {
            ChannelId = channelId;
            TopMsgId = topMsgId;
            ReadMaxId = readMaxId;

        }
#nullable disable
        internal UpdateReadChannelDiscussionInbox()
        {
        }

        public override void UpdateFlags()
        {
            Flags = BroadcastId == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
            Flags = BroadcastPost == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            writer.WriteInt64(ChannelId);
            writer.WriteInt32(TopMsgId);
            writer.WriteInt32(ReadMaxId);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                writer.WriteInt64(BroadcastId.Value);
            }

            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                writer.WriteInt32(BroadcastPost.Value);
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
            var trychannelId = reader.ReadInt64();
            if (trychannelId.IsError)
            {
                return ReadResult<IObject>.Move(trychannelId);
            }
            ChannelId = trychannelId.Value;
            var trytopMsgId = reader.ReadInt32();
            if (trytopMsgId.IsError)
            {
                return ReadResult<IObject>.Move(trytopMsgId);
            }
            TopMsgId = trytopMsgId.Value;
            var tryreadMaxId = reader.ReadInt32();
            if (tryreadMaxId.IsError)
            {
                return ReadResult<IObject>.Move(tryreadMaxId);
            }
            ReadMaxId = tryreadMaxId.Value;
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var trybroadcastId = reader.ReadInt64();
                if (trybroadcastId.IsError)
                {
                    return ReadResult<IObject>.Move(trybroadcastId);
                }
                BroadcastId = trybroadcastId.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var trybroadcastPost = reader.ReadInt32();
                if (trybroadcastPost.IsError)
                {
                    return ReadResult<IObject>.Move(trybroadcastPost);
                }
                BroadcastPost = trybroadcastPost.Value;
            }

            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "updateReadChannelDiscussionInbox";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new UpdateReadChannelDiscussionInbox
            {
                Flags = Flags,
                ChannelId = ChannelId,
                TopMsgId = TopMsgId,
                ReadMaxId = ReadMaxId,
                BroadcastId = BroadcastId,
                BroadcastPost = BroadcastPost
            };
            return newClonedObject;

        }

        public override bool Compare(IObject other)
        {
            if (other is not UpdateReadChannelDiscussionInbox castedOther)
            {
                return true;
            }
            if (Flags != castedOther.Flags)
            {
                return true;
            }
            if (ChannelId != castedOther.ChannelId)
            {
                return true;
            }
            if (TopMsgId != castedOther.TopMsgId)
            {
                return true;
            }
            if (ReadMaxId != castedOther.ReadMaxId)
            {
                return true;
            }
            if (BroadcastId != castedOther.BroadcastId)
            {
                return true;
            }
            if (BroadcastPost != castedOther.BroadcastPost)
            {
                return true;
            }
            return false;

        }

#nullable disable
    }
}