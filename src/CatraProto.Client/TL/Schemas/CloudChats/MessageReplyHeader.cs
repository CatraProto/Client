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
    public partial class MessageReplyHeader : CatraProto.Client.TL.Schemas.CloudChats.MessageReplyHeaderBase
    {
        [Flags]
        public enum FlagsEnum
        {
            ReplyToPeerId = 1 << 0,
            ReplyToTopId = 1 << 1
        }

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1495959709; }

        [Newtonsoft.Json.JsonIgnore]
        public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("reply_to_msg_id")]
        public sealed override int ReplyToMsgId { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("reply_to_peer_id")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.PeerBase ReplyToPeerId { get; set; }

        [Newtonsoft.Json.JsonProperty("reply_to_top_id")]
        public sealed override int? ReplyToTopId { get; set; }


#nullable enable
        public MessageReplyHeader(int replyToMsgId)
        {
            ReplyToMsgId = replyToMsgId;

        }
#nullable disable
        internal MessageReplyHeader()
        {
        }

        public override void UpdateFlags()
        {
            Flags = ReplyToPeerId == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
            Flags = ReplyToTopId == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            writer.WriteInt32(ReplyToMsgId);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var checkreplyToPeerId = writer.WriteObject(ReplyToPeerId);
                if (checkreplyToPeerId.IsError)
                {
                    return checkreplyToPeerId;
                }
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                writer.WriteInt32(ReplyToTopId.Value);
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
            var tryreplyToMsgId = reader.ReadInt32();
            if (tryreplyToMsgId.IsError)
            {
                return ReadResult<IObject>.Move(tryreplyToMsgId);
            }
            ReplyToMsgId = tryreplyToMsgId.Value;
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var tryreplyToPeerId = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.PeerBase>();
                if (tryreplyToPeerId.IsError)
                {
                    return ReadResult<IObject>.Move(tryreplyToPeerId);
                }
                ReplyToPeerId = tryreplyToPeerId.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                var tryreplyToTopId = reader.ReadInt32();
                if (tryreplyToTopId.IsError)
                {
                    return ReadResult<IObject>.Move(tryreplyToTopId);
                }
                ReplyToTopId = tryreplyToTopId.Value;
            }

            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "messageReplyHeader";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new MessageReplyHeader
            {
                Flags = Flags,
                ReplyToMsgId = ReplyToMsgId
            };
            if (ReplyToPeerId is not null)
            {
                var cloneReplyToPeerId = (CatraProto.Client.TL.Schemas.CloudChats.PeerBase?)ReplyToPeerId.Clone();
                if (cloneReplyToPeerId is null)
                {
                    return null;
                }
                newClonedObject.ReplyToPeerId = cloneReplyToPeerId;
            }
            newClonedObject.ReplyToTopId = ReplyToTopId;
            return newClonedObject;

        }
#nullable disable
    }
}