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
namespace CatraProto.Client.TL.Schemas.CloudChats.Updates
{
    public partial class State : CatraProto.Client.TL.Schemas.CloudChats.Updates.StateBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1519637954; }

        [Newtonsoft.Json.JsonProperty("pts")]
        public sealed override int Pts { get; set; }

        [Newtonsoft.Json.JsonProperty("qts")]
        public sealed override int Qts { get; set; }

        [Newtonsoft.Json.JsonProperty("date")]
        public sealed override int Date { get; set; }

        [Newtonsoft.Json.JsonProperty("seq")]
        public sealed override int Seq { get; set; }

        [Newtonsoft.Json.JsonProperty("unread_count")]
        public sealed override int UnreadCount { get; set; }


#nullable enable
        public State(int pts, int qts, int date, int seq, int unreadCount)
        {
            Pts = pts;
            Qts = qts;
            Date = date;
            Seq = seq;
            UnreadCount = unreadCount;

        }
#nullable disable
        internal State()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt32(Pts);
            writer.WriteInt32(Qts);
            writer.WriteInt32(Date);
            writer.WriteInt32(Seq);
            writer.WriteInt32(UnreadCount);

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
            var tryqts = reader.ReadInt32();
            if (tryqts.IsError)
            {
                return ReadResult<IObject>.Move(tryqts);
            }
            Qts = tryqts.Value;
            var trydate = reader.ReadInt32();
            if (trydate.IsError)
            {
                return ReadResult<IObject>.Move(trydate);
            }
            Date = trydate.Value;
            var tryseq = reader.ReadInt32();
            if (tryseq.IsError)
            {
                return ReadResult<IObject>.Move(tryseq);
            }
            Seq = tryseq.Value;
            var tryunreadCount = reader.ReadInt32();
            if (tryunreadCount.IsError)
            {
                return ReadResult<IObject>.Move(tryunreadCount);
            }
            UnreadCount = tryunreadCount.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "updates.state";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new State
            {
                Pts = Pts,
                Qts = Qts,
                Date = Date,
                Seq = Seq,
                UnreadCount = UnreadCount
            };
            return newClonedObject;

        }
#nullable disable
    }
}