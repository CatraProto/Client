using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class UpdateBotShippingQuery : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1246823043; }

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

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt64(QueryId);
            writer.WriteInt64(UserId);

            writer.WriteBytes(Payload);
            var checkshippingAddress = writer.WriteObject(ShippingAddress);
            if (checkshippingAddress.IsError)
            {
                return checkshippingAddress;
            }

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryqueryId = reader.ReadInt64();
            if (tryqueryId.IsError)
            {
                return ReadResult<IObject>.Move(tryqueryId);
            }
            QueryId = tryqueryId.Value;
            var tryuserId = reader.ReadInt64();
            if (tryuserId.IsError)
            {
                return ReadResult<IObject>.Move(tryuserId);
            }
            UserId = tryuserId.Value;
            var trypayload = reader.ReadBytes();
            if (trypayload.IsError)
            {
                return ReadResult<IObject>.Move(trypayload);
            }
            Payload = trypayload.Value;
            var tryshippingAddress = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.PostAddressBase>();
            if (tryshippingAddress.IsError)
            {
                return ReadResult<IObject>.Move(tryshippingAddress);
            }
            ShippingAddress = tryshippingAddress.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "updateBotShippingQuery";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }
    }
}