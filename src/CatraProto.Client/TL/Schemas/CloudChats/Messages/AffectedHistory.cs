using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class AffectedHistory : CatraProto.Client.TL.Schemas.CloudChats.Messages.AffectedHistoryBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1269012015; }

        [Newtonsoft.Json.JsonProperty("pts")] public sealed override int Pts { get; set; }

        [Newtonsoft.Json.JsonProperty("pts_count")]
        public sealed override int PtsCount { get; set; }

        [Newtonsoft.Json.JsonProperty("offset")]
        public sealed override int Offset { get; set; }


#nullable enable
        public AffectedHistory(int pts, int ptsCount, int offset)
        {
            Pts = pts;
            PtsCount = ptsCount;
            Offset = offset;
        }
#nullable disable
        internal AffectedHistory()
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
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "messages.affectedHistory";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new AffectedHistory();
            newClonedObject.Pts = Pts;
            newClonedObject.PtsCount = PtsCount;
            newClonedObject.Offset = Offset;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not AffectedHistory castedOther)
            {
                return true;
            }

            if (Pts != castedOther.Pts)
            {
                return true;
            }

            if (PtsCount != castedOther.PtsCount)
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