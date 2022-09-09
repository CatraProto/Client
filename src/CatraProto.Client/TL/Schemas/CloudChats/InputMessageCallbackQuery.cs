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
    public partial class InputMessageCallbackQuery : CatraProto.Client.TL.Schemas.CloudChats.InputMessageBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1392895362; }

        [Newtonsoft.Json.JsonProperty("id")] public int Id { get; set; }

        [Newtonsoft.Json.JsonProperty("query_id")]
        public long QueryId { get; set; }


#nullable enable
        public InputMessageCallbackQuery(int id, long queryId)
        {
            Id = id;
            QueryId = queryId;
        }
#nullable disable
        internal InputMessageCallbackQuery()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt32(Id);
            writer.WriteInt64(QueryId);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryid = reader.ReadInt32();
            if (tryid.IsError)
            {
                return ReadResult<IObject>.Move(tryid);
            }

            Id = tryid.Value;
            var tryqueryId = reader.ReadInt64();
            if (tryqueryId.IsError)
            {
                return ReadResult<IObject>.Move(tryqueryId);
            }

            QueryId = tryqueryId.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "inputMessageCallbackQuery";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new InputMessageCallbackQuery();
            newClonedObject.Id = Id;
            newClonedObject.QueryId = QueryId;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not InputMessageCallbackQuery castedOther)
            {
                return true;
            }

            if (Id != castedOther.Id)
            {
                return true;
            }

            if (QueryId != castedOther.QueryId)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}