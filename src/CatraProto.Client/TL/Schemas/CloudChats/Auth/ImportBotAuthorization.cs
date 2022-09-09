using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Auth
{
    public partial class ImportBotAuthorization : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 1738800940; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

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
            var newClonedObject = new ImportBotAuthorization();
            newClonedObject.Flags = Flags;
            newClonedObject.ApiId = ApiId;
            newClonedObject.ApiHash = ApiHash;
            newClonedObject.BotAuthToken = BotAuthToken;
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