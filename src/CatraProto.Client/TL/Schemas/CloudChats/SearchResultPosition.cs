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
    public partial class SearchResultPosition : CatraProto.Client.TL.Schemas.CloudChats.SearchResultsPositionBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 2137295719; }

        [Newtonsoft.Json.JsonProperty("msg_id")]
        public sealed override int MsgId { get; set; }

        [Newtonsoft.Json.JsonProperty("date")] public sealed override int Date { get; set; }

        [Newtonsoft.Json.JsonProperty("offset")]
        public sealed override int Offset { get; set; }


#nullable enable
        public SearchResultPosition(int msgId, int date, int offset)
        {
            MsgId = msgId;
            Date = date;
            Offset = offset;
        }
#nullable disable
        internal SearchResultPosition()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt32(MsgId);
            writer.WriteInt32(Date);
            writer.WriteInt32(Offset);

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
            var trydate = reader.ReadInt32();
            if (trydate.IsError)
            {
                return ReadResult<IObject>.Move(trydate);
            }

            Date = trydate.Value;
            var tryoffset = reader.ReadInt32();
            if (tryoffset.IsError)
            {
                return ReadResult<IObject>.Move(tryoffset);
            }

            Offset = tryoffset.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "searchResultPosition";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new SearchResultPosition();
            newClonedObject.MsgId = MsgId;
            newClonedObject.Date = Date;
            newClonedObject.Offset = Offset;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not SearchResultPosition castedOther)
            {
                return true;
            }

            if (MsgId != castedOther.MsgId)
            {
                return true;
            }

            if (Date != castedOther.Date)
            {
                return true;
            }

            if (Offset != castedOther.Offset)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}