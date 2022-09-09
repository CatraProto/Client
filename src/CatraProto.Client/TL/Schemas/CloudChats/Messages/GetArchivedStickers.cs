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
    public partial class GetArchivedStickers : IMethod
    {
        [Flags]
        public enum FlagsEnum
        {
            Masks = 1 << 0
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 1475442322; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("masks")]
        public bool Masks { get; set; }

        [Newtonsoft.Json.JsonProperty("offset_id")]
        public long OffsetId { get; set; }

        [Newtonsoft.Json.JsonProperty("limit")]
        public int Limit { get; set; }


#nullable enable
        public GetArchivedStickers(long offsetId, int limit)
        {
            OffsetId = offsetId;
            Limit = limit;
        }
#nullable disable

        internal GetArchivedStickers()
        {
        }

        public void UpdateFlags()
        {
            Flags = Masks ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            writer.WriteInt64(OffsetId);
            writer.WriteInt32(Limit);

            return new WriteResult();
        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryflags = reader.ReadInt32();
            if (tryflags.IsError)
            {
                return ReadResult<IObject>.Move(tryflags);
            }

            Flags = tryflags.Value;
            Masks = FlagsHelper.IsFlagSet(Flags, 0);
            var tryoffsetId = reader.ReadInt64();
            if (tryoffsetId.IsError)
            {
                return ReadResult<IObject>.Move(tryoffsetId);
            }

            OffsetId = tryoffsetId.Value;
            var trylimit = reader.ReadInt32();
            if (trylimit.IsError)
            {
                return ReadResult<IObject>.Move(trylimit);
            }

            Limit = trylimit.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "messages.getArchivedStickers";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new GetArchivedStickers();
            newClonedObject.Flags = Flags;
            newClonedObject.Masks = Masks;
            newClonedObject.OffsetId = OffsetId;
            newClonedObject.Limit = Limit;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not GetArchivedStickers castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (Masks != castedOther.Masks)
            {
                return true;
            }

            if (OffsetId != castedOther.OffsetId)
            {
                return true;
            }

            if (Limit != castedOther.Limit)
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}