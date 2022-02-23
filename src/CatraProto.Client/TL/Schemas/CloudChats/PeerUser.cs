using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class PeerUser : CatraProto.Client.TL.Schemas.CloudChats.PeerBase
    {
        public static int StaticConstructorId
        {
            get => 1498486562;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("user_id")]
        public long UserId { get; set; }


    #nullable enable
        public PeerUser(long userId)
        {
            UserId = userId;
        }
    #nullable disable
        internal PeerUser()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(UserId);
        }

        public override void Deserialize(Reader reader)
        {
            UserId = reader.Read<long>();
        }

        public override string ToString()
        {
            return "peerUser";
        }
    }
}