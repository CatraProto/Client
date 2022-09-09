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
    public partial class UpdateWebViewResultSent : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 361936797; }

        [Newtonsoft.Json.JsonProperty("query_id")]
        public long QueryId { get; set; }


#nullable enable
        public UpdateWebViewResultSent(long queryId)
        {
            QueryId = queryId;
        }
#nullable disable
        internal UpdateWebViewResultSent()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt64(QueryId);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
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
            return "updateWebViewResultSent";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new UpdateWebViewResultSent();
            newClonedObject.QueryId = QueryId;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not UpdateWebViewResultSent castedOther)
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