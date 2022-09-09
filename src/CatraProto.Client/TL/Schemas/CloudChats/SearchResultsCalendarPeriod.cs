using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class SearchResultsCalendarPeriod : CatraProto.Client.TL.Schemas.CloudChats.SearchResultsCalendarPeriodBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -911191137; }

        [Newtonsoft.Json.JsonProperty("date")] public sealed override int Date { get; set; }

        [Newtonsoft.Json.JsonProperty("min_msg_id")]
        public sealed override int MinMsgId { get; set; }

        [Newtonsoft.Json.JsonProperty("max_msg_id")]
        public sealed override int MaxMsgId { get; set; }

        [Newtonsoft.Json.JsonProperty("count")]
        public sealed override int Count { get; set; }


#nullable enable
        public SearchResultsCalendarPeriod(int date, int minMsgId, int maxMsgId, int count)
        {
            Date = date;
            MinMsgId = minMsgId;
            MaxMsgId = maxMsgId;
            Count = count;
        }
#nullable disable
        internal SearchResultsCalendarPeriod()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt32(Date);
            writer.WriteInt32(MinMsgId);
            writer.WriteInt32(MaxMsgId);
            writer.WriteInt32(Count);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trydate = reader.ReadInt32();
            if (trydate.IsError)
            {
                return ReadResult<IObject>.Move(trydate);
            }

            Date = trydate.Value;
            var tryminMsgId = reader.ReadInt32();
            if (tryminMsgId.IsError)
            {
                return ReadResult<IObject>.Move(tryminMsgId);
            }

            MinMsgId = tryminMsgId.Value;
            var trymaxMsgId = reader.ReadInt32();
            if (trymaxMsgId.IsError)
            {
                return ReadResult<IObject>.Move(trymaxMsgId);
            }

            MaxMsgId = trymaxMsgId.Value;
            var trycount = reader.ReadInt32();
            if (trycount.IsError)
            {
                return ReadResult<IObject>.Move(trycount);
            }

            Count = trycount.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "searchResultsCalendarPeriod";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new SearchResultsCalendarPeriod();
            newClonedObject.Date = Date;
            newClonedObject.MinMsgId = MinMsgId;
            newClonedObject.MaxMsgId = MaxMsgId;
            newClonedObject.Count = Count;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not SearchResultsCalendarPeriod castedOther)
            {
                return true;
            }

            if (Date != castedOther.Date)
            {
                return true;
            }

            if (MinMsgId != castedOther.MinMsgId)
            {
                return true;
            }

            if (MaxMsgId != castedOther.MaxMsgId)
            {
                return true;
            }

            if (Count != castedOther.Count)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}