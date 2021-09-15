using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class AcceptEncryption : IMethod
    {
        [JsonIgnore]
        public static int StaticConstructorId
        {
            get => 1035731989;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(EncryptedChatBase);

        [JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [JsonProperty("peer")] public InputEncryptedChatBase Peer { get; set; }

        [JsonProperty("g_b")] public byte[] GB { get; set; }

        [JsonProperty("key_fingerprint")] public long KeyFingerprint { get; set; }

        public override string ToString()
        {
            return "messages.acceptEncryption";
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

            writer.Write(Peer);
            writer.Write(GB);
            writer.Write(KeyFingerprint);
        }

        public void Deserialize(Reader reader)
        {
            Peer = reader.Read<InputEncryptedChatBase>();
            GB = reader.Read<byte[]>();
            KeyFingerprint = reader.Read<long>();
        }
    }
}