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

namespace CatraProto.Client.TL.Schemas.CloudChats.Auth
{
    public partial class ImportBotAuthorization : IMethod
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1738800940; }

        [Newtonsoft.Json.JsonIgnore]
        ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("flags")]
        public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("api_id")]
        public int ApiId { get; set; }

        [Newtonsoft.Json.JsonProperty("api_hash")]
        public string ApiHash { get; set; }

        [Newtonsoft.Json.JsonProperty("bot_auth_token")]
        public string BotAuthToken { get; set; }


#nullable enable
        public ImportBotAuthorization(int flags, int apiId, string apiHash, string botAuthToken)
        {
            Flags = flags;
            ApiId = apiId;
            ApiHash = apiHash;
            BotAuthToken = botAuthToken;

        }
#nullable disable

        internal ImportBotAuthorization()
        {
        }

        public void UpdateFlags()
        {

        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt32(Flags);
            writer.WriteInt32(ApiId);

            writer.WriteString(ApiHash);

            writer.WriteString(BotAuthToken);

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
            var trybotAuthToken = reader.ReadString();
            if (trybotAuthToken.IsError)
            {
                return ReadResult<IObject>.Move(trybotAuthToken);
            }
            BotAuthToken = trybotAuthToken.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "auth.importBotAuthorization";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new ImportBotAuthorization
            {
                Flags = Flags,
                ApiId = ApiId,
                ApiHash = ApiHash,
                BotAuthToken = BotAuthToken
            };
            return newClonedObject;

        }

        public bool Compare(IObject other)
        {
            if (other is not ImportBotAuthorization castedOther)
            {
                return true;
            }
            if (Flags != castedOther.Flags)
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
            if (BotAuthToken != castedOther.BotAuthToken)
            {
                return true;
            }
            return false;

        }
#nullable disable
    }
}