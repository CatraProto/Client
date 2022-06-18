/*
CatraProto, a C# library that implements the MTProto protocol and the Telegram API.
Copyright (C) 2022 Aquatica <aquathing@protonmail.com>

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Lesser General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Lesser General Public License for more details.

You should have received a copy of the GNU Lesser General Public License
along with this program.  If not, see <https://www.gnu.org/licenses/>.
*/

using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class WebViewResultUrl : CatraProto.Client.TL.Schemas.CloudChats.WebViewResultBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 202659196; }

        [Newtonsoft.Json.JsonProperty("query_id")]
        public sealed override long QueryId { get; set; }

        [Newtonsoft.Json.JsonProperty("url")]
        public sealed override string Url { get; set; }


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
            var newClonedObject = new WebViewResultUrl
            {
                QueryId = QueryId,
                Url = Url
            };
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