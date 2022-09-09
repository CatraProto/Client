using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Updates
{
    public partial class State : CatraProto.Client.TL.Schemas.CloudChats.Updates.StateBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1519637954; }

        [Newtonsoft.Json.JsonProperty("pts")] public sealed override int Pts { get; set; }

        [Newtonsoft.Json.JsonProperty("qts")] public sealed override int Qts { get; set; }

        [Newtonsoft.Json.JsonProperty("date")] public sealed override int Date { get; set; }

        [Newtonsoft.Json.JsonProperty("seq")] public sealed override int Seq { get; set; }

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
            var newClonedObject = new State();
            newClonedObject.Pts = Pts;
            newClonedObject.Qts = Qts;
            newClonedObject.Date = Date;
            newClonedObject.Seq = Seq;
            newClonedObject.UnreadCount = UnreadCount;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not State castedOther)
            {
                return true;
            }

            if (Pts != castedOther.Pts)
            {
                return true;
            }

            if (Qts != castedOther.Qts)
            {
                return true;
            }

            if (Date != castedOther.Date)
            {
                return true;
            }

            if (Seq != castedOther.Seq)
            {
                return true;
            }

            if (UnreadCount != castedOther.UnreadCount)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}