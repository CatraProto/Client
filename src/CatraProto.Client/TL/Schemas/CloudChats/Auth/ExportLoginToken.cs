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

using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Auth
{
    public partial class ExportLoginToken : IMethod
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1210022402; }

        [Newtonsoft.Json.JsonIgnore]
        ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("api_id")]
        public int ApiId { get; set; }

        [Newtonsoft.Json.JsonProperty("api_hash")]
        public string ApiHash { get; set; }

        [Newtonsoft.Json.JsonProperty("except_ids")]
        public List<long> ExceptIds { get; set; }


#nullable enable
        public ExportLoginToken(int apiId, string apiHash, List<long> exceptIds)
        {
            ApiId = apiId;
            ApiHash = apiHash;
            ExceptIds = exceptIds;

        }
#nullable disable

        internal ExportLoginToken()
        {
        }

        public void UpdateFlags()
        {

        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt32(ApiId);

            writer.WriteString(ApiHash);

            writer.WriteVector(ExceptIds, false);

            return new WriteResult();

        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryapiId = reader.ReadInt32();
            if (tryapiId.IsError)
            {
                return ReadResult<IObject>.Move(tryapiId);
            }
            ApiId = tryapiId.Value;
            var tryapiHash = reader.ReadString();
            if (tryapiHash.IsError)
            {
                return ReadResult<IObject>.Move(tryapiHash);
            }
            ApiHash = tryapiHash.Value;
            var tryexceptIds = reader.ReadVector<long>(ParserTypes.Int64);
            if (tryexceptIds.IsError)
            {
                return ReadResult<IObject>.Move(tryexceptIds);
            }
            ExceptIds = tryexceptIds.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "auth.exportLoginToken";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new ExportLoginToken
            {
                ApiId = ApiId,
                ApiHash = ApiHash,
                ExceptIds = new List<long>()
            };
            foreach (var exceptIds in ExceptIds)
            {
                newClonedObject.ExceptIds.Add(exceptIds);
            }
            return newClonedObject;

        }

        public bool Compare(IObject other)
        {
            if (other is not ExportLoginToken castedOther)
            {
                return true;
            }
            if (ApiId != castedOther.ApiId)
            {
                return true;
            }
            if (ApiHash != castedOther.ApiHash)
            {
                return true;
            }
            var exceptIdssize = castedOther.ExceptIds.Count;
            if (exceptIdssize != ExceptIds.Count)
            {
                return true;
            }
            for (var i = 0; i < exceptIdssize; i++)
            {
                if (castedOther.ExceptIds[i] != ExceptIds[i])
                {
                    return true;
                }
            }
            return false;

        }
#nullable disable
    }
}