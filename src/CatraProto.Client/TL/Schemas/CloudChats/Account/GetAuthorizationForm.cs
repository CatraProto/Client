using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public partial class GetAuthorizationForm : IMethod
    {
        [JsonIgnore]
        public static int StaticConstructorId
        {
            get => -1200903967;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(AuthorizationFormBase);

        [JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [JsonProperty("bot_id")] public int BotId { get; set; }

        [JsonProperty("scope")] public string Scope { get; set; }

        [JsonProperty("public_key")] public string PublicKey { get; set; }

        public override string ToString()
        {
            return "account.getAuthorizationForm";
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

            writer.Write(BotId);
            writer.Write(Scope);
            writer.Write(PublicKey);
        }

        public void Deserialize(Reader reader)
        {
            BotId = reader.Read<int>();
            Scope = reader.Read<string>();
            PublicKey = reader.Read<string>();
        }
    }
}