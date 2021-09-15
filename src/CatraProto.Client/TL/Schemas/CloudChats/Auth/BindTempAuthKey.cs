using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Auth
{
    public partial class BindTempAuthKey : IMethod
    {
        [JsonIgnore]
        public static int StaticConstructorId
        {
            get => -841733627;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(bool);

        [JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [JsonProperty("perm_auth_key_id")] public long PermAuthKeyId { get; set; }

        [JsonProperty("nonce")] public long Nonce { get; set; }

        [JsonProperty("expires_at")] public int ExpiresAt { get; set; }

        [JsonProperty("encrypted_message")] public byte[] EncryptedMessage { get; set; }

        public override string ToString()
        {
            return "auth.bindTempAuthKey";
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

            writer.Write(PermAuthKeyId);
            writer.Write(Nonce);
            writer.Write(ExpiresAt);
            writer.Write(EncryptedMessage);
        }

        public void Deserialize(Reader reader)
        {
            PermAuthKeyId = reader.Read<long>();
            Nonce = reader.Read<long>();
            ExpiresAt = reader.Read<int>();
            EncryptedMessage = reader.Read<byte[]>();
        }
    }
}