using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Phone
{
    public partial class ConfirmCall : IMethod
    {
        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId
        {
            get => 788404002;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonIgnore] System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Phone.PhoneCallBase);

        [Newtonsoft.Json.JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [Newtonsoft.Json.JsonProperty("peer")] public CatraProto.Client.TL.Schemas.CloudChats.InputPhoneCallBase Peer { get; set; }

        [Newtonsoft.Json.JsonProperty("g_a")] public byte[] GA { get; set; }

        [Newtonsoft.Json.JsonProperty("key_fingerprint")]
        public long KeyFingerprint { get; set; }

        [Newtonsoft.Json.JsonProperty("protocol")]
        public CatraProto.Client.TL.Schemas.CloudChats.PhoneCallProtocolBase Protocol { get; set; }


    #nullable enable
        public ConfirmCall(CatraProto.Client.TL.Schemas.CloudChats.InputPhoneCallBase peer, byte[] gA, long keyFingerprint, CatraProto.Client.TL.Schemas.CloudChats.PhoneCallProtocolBase protocol)
        {
            Peer = peer;
            GA = gA;
            KeyFingerprint = keyFingerprint;
            Protocol = protocol;
        }
    #nullable disable

        internal ConfirmCall()
        {
        }

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(Peer);
            writer.Write(GA);
            writer.Write(KeyFingerprint);
            writer.Write(Protocol);
        }

        public void Deserialize(Reader reader)
        {
            Peer = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputPhoneCallBase>();
            GA = reader.Read<byte[]>();
            KeyFingerprint = reader.Read<long>();
            Protocol = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.PhoneCallProtocolBase>();
        }

        public override string ToString()
        {
            return "phone.confirmCall";
        }
    }
}