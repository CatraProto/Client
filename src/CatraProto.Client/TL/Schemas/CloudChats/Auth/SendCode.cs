using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Auth
{
    public partial class SendCode : IMethod
    {
        [JsonIgnore]
        public static int StaticConstructorId
        {
            get => -1502141361;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(SentCodeBase);

        [JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [JsonProperty("phone_number")] public string PhoneNumber { get; set; }

        [JsonProperty("api_id")] public int ApiId { get; set; }

        [JsonProperty("api_hash")] public string ApiHash { get; set; }

        [JsonProperty("settings")] public CodeSettingsBase Settings { get; set; }

        public override string ToString()
        {
            return "auth.sendCode";
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

            writer.Write(PhoneNumber);
            writer.Write(ApiId);
            writer.Write(ApiHash);
            writer.Write(Settings);
        }

        public void Deserialize(Reader reader)
        {
            PhoneNumber = reader.Read<string>();
            ApiId = reader.Read<int>();
            ApiHash = reader.Read<string>();
            Settings = reader.Read<CodeSettingsBase>();
        }
    }
}