using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class UpdateBotShippingQuery : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
    {
        public static int StaticConstructorId
        {
            get => -1246823043;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("query_id")]
        public long QueryId { get; set; }

        [Newtonsoft.Json.JsonProperty("user_id")]
        public long UserId { get; set; }

        [Newtonsoft.Json.JsonProperty("payload")]
        public byte[] Payload { get; set; }

        [Newtonsoft.Json.JsonProperty("shipping_address")]
        public CatraProto.Client.TL.Schemas.CloudChats.PostAddressBase ShippingAddress { get; set; }


    #nullable enable
        public UpdateBotShippingQuery(long queryId, long userId, byte[] payload, CatraProto.Client.TL.Schemas.CloudChats.PostAddressBase shippingAddress)
        {
            QueryId = queryId;
            UserId = userId;
            Payload = payload;
            ShippingAddress = shippingAddress;
        }
    #nullable disable
        internal UpdateBotShippingQuery()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(QueryId);
            writer.Write(UserId);
            writer.Write(Payload);
            writer.Write(ShippingAddress);
        }

        public override void Deserialize(Reader reader)
        {
            QueryId = reader.Read<long>();
            UserId = reader.Read<long>();
            Payload = reader.Read<byte[]>();
            ShippingAddress = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.PostAddressBase>();
        }

        public override string ToString()
        {
            return "updateBotShippingQuery";
        }
    }
}