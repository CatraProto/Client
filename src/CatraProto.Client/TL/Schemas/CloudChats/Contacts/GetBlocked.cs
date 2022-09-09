using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Contacts
{
    public partial class GetBlocked : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -176409329; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("offset")]
        public int Offset { get; set; }

        [Newtonsoft.Json.JsonProperty("limit")]
        public int Limit { get; set; }


#nullable enable
        public GetBlocked(int offset, int limit)
        {
            Offset = offset;
            Limit = limit;
        }
#nullable disable

        internal GetBlocked()
        {
        }

        public void UpdateFlags()
        {
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt32(Offset);
            writer.WriteInt32(Limit);

            return new WriteResult();
        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryoffset = reader.ReadInt32();
            if (tryoffset.IsError)
            {
                return ReadResult<IObject>.Move(tryoffset);
            }

            Offset = tryoffset.Value;
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
            return "contacts.getBlocked";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new GetBlocked();
            newClonedObject.Offset = Offset;
            newClonedObject.Limit = Limit;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not GetBlocked castedOther)
            {
                return true;
            }

            if (Offset != castedOther.Offset)
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