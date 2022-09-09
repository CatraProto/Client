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
    public partial class InvokeWithTakeout : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1398145746; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("takeout_id")]
        public long TakeoutId { get; set; }

        [Newtonsoft.Json.JsonProperty("query")]
        public IObject Query { get; set; }


#nullable enable
        public InvokeWithTakeout(long takeoutId, IObject query)
        {
            TakeoutId = takeoutId;
            Query = query;
        }
#nullable disable

        internal InvokeWithTakeout()
        {
        }

        public void UpdateFlags()
        {
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt64(TakeoutId);
            var checkquery = writer.WriteObject(Query);
            if (checkquery.IsError)
            {
                return checkquery;
            }

            return new WriteResult();
        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var trytakeoutId = reader.ReadInt64();
            if (trytakeoutId.IsError)
            {
                return ReadResult<IObject>.Move(trytakeoutId);
            }

            TakeoutId = trytakeoutId.Value;
            var tryquery = reader.ReadObject<IObject>();
            if (tryquery.IsError)
            {
                return ReadResult<IObject>.Move(tryquery);
            }

            Query = tryquery.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "invokeWithTakeout";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new InvokeWithTakeout();
            newClonedObject.TakeoutId = TakeoutId;
            newClonedObject.Query = Query;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not InvokeWithTakeout castedOther)
            {
                return true;
            }

            if (TakeoutId != castedOther.TakeoutId)
            {
                return true;
            }

            if (Query != castedOther.Query)
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}