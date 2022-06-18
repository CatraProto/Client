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

using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class UpdateChannelReadMessagesContents : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1153291573; }

        [Newtonsoft.Json.JsonProperty("channel_id")]
        public long ChannelId { get; set; }

        [Newtonsoft.Json.JsonProperty("messages")]
        public List<int> Messages { get; set; }


#nullable enable
        public UpdateChannelReadMessagesContents(long channelId, List<int> messages)
        {
            ChannelId = channelId;
            Messages = messages;

        }
#nullable disable
        internal UpdateChannelReadMessagesContents()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt64(ChannelId);

            writer.WriteVector(Messages, false);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
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
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "updateChannelReadMessagesContents";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new UpdateChannelReadMessagesContents
            {
                ChannelId = ChannelId,
                Messages = new List<int>()
            };
            foreach (var messages in Messages)
            {
                newClonedObject.Messages.Add(messages);
            }
            return newClonedObject;

        }

        public override bool Compare(IObject other)
        {
            if (other is not UpdateChannelReadMessagesContents castedOther)
            {
                return true;
            }
            if (ChannelId != castedOther.ChannelId)
            {
                return true;
            }
            var messagessize = castedOther.Messages.Count;
            if (messagessize != Messages.Count)
            {
                return true;
            }
            for (var i = 0; i < messagessize; i++)
            {
                if (castedOther.Messages[i] != Messages[i])
                {
                    return true;
                }
            }
            return false;

        }

#nullable disable
    }
}