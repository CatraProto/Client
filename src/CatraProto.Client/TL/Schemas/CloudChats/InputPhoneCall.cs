using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class InputPhoneCall : CatraProto.Client.TL.Schemas.CloudChats.InputPhoneCallBase
    {
        public static int StaticConstructorId
        {
            get => 506920429;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("id")] public sealed override long Id { get; set; }

        [Newtonsoft.Json.JsonProperty("access_hash")]
        public sealed override long AccessHash { get; set; }


    #nullable enable
        public InputPhoneCall(long id, long accessHash)
        {
            Id = id;
            AccessHash = accessHash;
        }
    #nullable disable
        internal InputPhoneCall()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(Id);
            writer.Write(AccessHash);
        }

        public override void Deserialize(Reader reader)
        {
            Id = reader.Read<long>();
            AccessHash = reader.Read<long>();
        }

        public override string ToString()
        {
            return "inputPhoneCall";
        }
    }
}