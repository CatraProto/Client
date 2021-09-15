using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Auth
{
    public partial class ImportBotAuthorization : IMethod
    {
        [JsonIgnore]
        public static int StaticConstructorId
        {
            get => 1738800940;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(AuthorizationBase);

        [JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [JsonProperty("flags")] public int Flags { get; set; }

        [JsonProperty("api_id")] public int ApiId { get; set; }

        [JsonProperty("api_hash")] public string ApiHash { get; set; }

        [JsonProperty("bot_auth_token")] public string BotAuthToken { get; set; }

        public override string ToString()
        {
            return "auth.importBotAuthorization";
        }


        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            writer.Write(Flags);
            writer.Write(ApiId);
            writer.Write(ApiHash);
            writer.Write(BotAuthToken);
        }

        public void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            ApiId = reader.Read<int>();
            ApiHash = reader.Read<string>();
            BotAuthToken = reader.Read<string>();
        }
    }
}