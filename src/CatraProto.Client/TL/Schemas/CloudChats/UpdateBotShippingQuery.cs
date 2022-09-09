using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class UpdateBotShippingQuery : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1246823043; }

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

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new UpdateBotShippingQuery();
            newClonedObject.QueryId = QueryId;
            newClonedObject.UserId = UserId;
            newClonedObject.Payload = Payload;
            var cloneShippingAddress = (CatraProto.Client.TL.Schemas.CloudChats.PostAddressBase?)ShippingAddress.Clone();
            if (cloneShippingAddress is null)
            {
                return null;
            }

            newClonedObject.ShippingAddress = cloneShippingAddress;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not UpdateBotShippingQuery castedOther)
            {
                return true;
            }

            if (QueryId != castedOther.QueryId)
            {
                return true;
            }

            if (UserId != castedOther.UserId)
            {
                return true;
            }

            if (Payload != castedOther.Payload)
            {
                return true;
            }

            if (ShippingAddress.Compare(castedOther.ShippingAddress))
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}