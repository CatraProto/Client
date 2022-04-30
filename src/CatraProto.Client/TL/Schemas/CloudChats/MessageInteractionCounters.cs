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

using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class MessageInteractionCounters : CatraProto.Client.TL.Schemas.CloudChats.MessageInteractionCountersBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1387279939; }

        [Newtonsoft.Json.JsonProperty("msg_id")]
        public sealed override int MsgId { get; set; }

        [Newtonsoft.Json.JsonProperty("views")]
        public sealed override int Views { get; set; }

        [Newtonsoft.Json.JsonProperty("forwards")]
        public sealed override int Forwards { get; set; }


#nullable enable
        public MessageInteractionCounters(int msgId, int views, int forwards)
        {
            MsgId = msgId;
            Views = views;
            Forwards = forwards;

        }
#nullable disable
        internal MessageInteractionCounters()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt32(MsgId);
            writer.WriteInt32(Views);
            writer.WriteInt32(Forwards);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trymsgId = reader.ReadInt32();
            if (trymsgId.IsError)
            {
                return ReadResult<IObject>.Move(trymsgId);
            }
            MsgId = trymsgId.Value;
            var tryviews = reader.ReadInt32();
            if (tryviews.IsError)
            {
                return ReadResult<IObject>.Move(tryviews);
            }
            Views = tryviews.Value;
            var tryforwards = reader.ReadInt32();
            if (tryforwards.IsError)
            {
                return ReadResult<IObject>.Move(tryforwards);
            }
            Forwards = tryforwards.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "messageInteractionCounters";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new MessageInteractionCounters
            {
                MsgId = MsgId,
                Views = Views,
                Forwards = Forwards
            };
            return newClonedObject;

        }
#nullable disable
    }
}