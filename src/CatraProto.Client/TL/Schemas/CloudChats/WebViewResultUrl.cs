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
    public partial class WebViewResultUrl : CatraProto.Client.TL.Schemas.CloudChats.WebViewResultBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 202659196; }

        [Newtonsoft.Json.JsonProperty("query_id")]
        public sealed override long QueryId { get; set; }

        [Newtonsoft.Json.JsonProperty("url")] public sealed override string Url { get; set; }


#nullable enable
        public WebViewResultUrl(long queryId, string url)
        {
            QueryId = queryId;
            Url = url;
        }
#nullable disable
        internal WebViewResultUrl()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt64(QueryId);

            writer.WriteString(Url);

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
            var tryurl = reader.ReadString();
            if (tryurl.IsError)
            {
                return ReadResult<IObject>.Move(tryurl);
            }

            Url = tryurl.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "webViewResultUrl";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new WebViewResultUrl();
            newClonedObject.QueryId = QueryId;
            newClonedObject.Url = Url;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not WebViewResultUrl castedOther)
            {
                return true;
            }

            if (QueryId != castedOther.QueryId)
            {
                return true;
            }

            if (Url != castedOther.Url)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}