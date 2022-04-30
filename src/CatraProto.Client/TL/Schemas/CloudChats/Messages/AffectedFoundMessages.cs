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
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class AffectedFoundMessages : CatraProto.Client.TL.Schemas.CloudChats.Messages.AffectedFoundMessagesBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -275956116; }

        [Newtonsoft.Json.JsonProperty("pts")]
        public sealed override int Pts { get; set; }

        [Newtonsoft.Json.JsonProperty("pts_count")]
        public sealed override int PtsCount { get; set; }

        [Newtonsoft.Json.JsonProperty("offset")]
        public sealed override int Offset { get; set; }

        [Newtonsoft.Json.JsonProperty("messages")]
        public sealed override List<int> Messages { get; set; }


#nullable enable
        public AffectedFoundMessages(int pts, int ptsCount, int offset, List<int> messages)
        {
            Pts = pts;
            PtsCount = ptsCount;
            Offset = offset;
            Messages = messages;

        }
#nullable disable
        internal AffectedFoundMessages()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt32(Pts);
            writer.WriteInt32(PtsCount);
            writer.WriteInt32(Offset);

            writer.WriteVector(Messages, false);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
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
            var tryoffset = reader.ReadInt32();
            if (tryoffset.IsError)
            {
                return ReadResult<IObject>.Move(tryoffset);
            }
            Offset = tryoffset.Value;
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
            return "messages.affectedFoundMessages";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new AffectedFoundMessages
            {
                Pts = Pts,
                PtsCount = PtsCount,
                Offset = Offset
            };
            foreach (var messages in Messages)
            {
                newClonedObject.Messages.Add(messages);
            }
            return newClonedObject;

        }
#nullable disable
    }
}