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
    public partial class InvokeWithMessagesRange : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 911373810; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("range")]
        public CatraProto.Client.TL.Schemas.CloudChats.MessageRangeBase Range { get; set; }

        [Newtonsoft.Json.JsonProperty("query")]
        public IObject Query { get; set; }


#nullable enable
        public InvokeWithMessagesRange(CatraProto.Client.TL.Schemas.CloudChats.MessageRangeBase range, IObject query)
        {
            Range = range;
            Query = query;
        }
#nullable disable

        internal InvokeWithMessagesRange()
        {
        }

        public void UpdateFlags()
        {
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkrange = writer.WriteObject(Range);
            if (checkrange.IsError)
            {
                return checkrange;
            }

            var checkquery = writer.WriteObject(Query);
            if (checkquery.IsError)
            {
                return checkquery;
            }

            return new WriteResult();
        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryrange = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.MessageRangeBase>();
            if (tryrange.IsError)
            {
                return ReadResult<IObject>.Move(tryrange);
            }

            Range = tryrange.Value;
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
            return "invokeWithMessagesRange";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new InvokeWithMessagesRange();
            var cloneRange = (CatraProto.Client.TL.Schemas.CloudChats.MessageRangeBase?)Range.Clone();
            if (cloneRange is null)
            {
                return null;
            }

            newClonedObject.Range = cloneRange;
            newClonedObject.Query = Query;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not InvokeWithMessagesRange castedOther)
            {
                return true;
            }

            if (Range.Compare(castedOther.Range))
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