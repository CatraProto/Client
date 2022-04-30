/*
CatraProto, a C# library that implements the MTProto protocol and the Telegram API.
Copyright (C) 2022 Aquatica <aquathing@protonmail.com>

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Lesser General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Lesser General Public License for more details.

You should have received a copy of the GNU Lesser General Public License
along with this program.  If not, see <https://www.gnu.org/licenses/>.
*/

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

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new UpdateBotShippingQuery
            {
                QueryId = QueryId,
                UserId = UserId,
                Payload = Payload
            };
            var cloneShippingAddress = (CatraProto.Client.TL.Schemas.CloudChats.PostAddressBase?)ShippingAddress.Clone();
            if (cloneShippingAddress is null)
            {
                return null;
            }
            newClonedObject.ShippingAddress = cloneShippingAddress;
            return newClonedObject;

        }
#nullable disable
    }
}