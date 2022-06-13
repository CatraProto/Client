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
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class UpdatePinnedChannelMessages : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Pinned = 1 << 0
        }

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1538885128; }

        [Newtonsoft.Json.JsonIgnore]
        public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("pinned")]
        public bool Pinned { get; set; }

        [Newtonsoft.Json.JsonProperty("channel_id")]
        public long ChannelId { get; set; }

        [Newtonsoft.Json.JsonProperty("messages")]
        public List<int> Messages { get; set; }

        [Newtonsoft.Json.JsonProperty("pts")]
        public int Pts { get; set; }

        [Newtonsoft.Json.JsonProperty("pts_count")]
        public int PtsCount { get; set; }


#nullable enable
        public UpdatePinnedChannelMessages(long channelId, List<int> messages, int pts, int ptsCount)
        {
            ChannelId = channelId;
            Messages = messages;
            Pts = pts;
            PtsCount = ptsCount;

        }
#nullable disable
        internal UpdatePinnedChannelMessages()
        {
        }

        public override void UpdateFlags()
        {
            Flags = Pinned ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            writer.WriteInt64(ChannelId);

            writer.WriteVector(Messages, false);
            writer.WriteInt32(Pts);
            writer.WriteInt32(PtsCount);

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
            Pinned = FlagsHelper.IsFlagSet(Flags, 0);
            var trychannelId = reader.ReadInt64();
            if (trychannelId.IsError)
            {
                return ReadResult<IObject>.Move(trychannelId);
            }
            ChannelId = trychannelId.Value;
            var trymessages = reader.ReadVector<int>(ParserTypes.Int);
            if (trymessages.IsError)
            {
                return ReadResult<IObject>.Move(trymessages);
            }
            Messages = trymessages.Value;
            var trypts = reader.ReadInt32();
            if (trypts.IsError)
            {
                return ReadResult<IObject>.Move(trypts);
            }
            Pts = trypts.Value;
            var tryptsCount = reader.ReadInt32();
            if (tryptsCount.IsError)
            {
                return ReadResult<IObject>.Move(tryptsCount);
            }
            PtsCount = tryptsCount.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "updatePinnedChannelMessages";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new UpdatePinnedChannelMessages
            {
                Flags = Flags,
                Pinned = Pinned,
                ChannelId = ChannelId,
                Messages = new List<int>()
            };
            foreach (var messages in Messages)
            {
                newClonedObject.Messages.Add(messages);
            }
            newClonedObject.Pts = Pts;
            newClonedObject.PtsCount = PtsCount;
            return newClonedObject;

        }
#nullable disable
    }
}