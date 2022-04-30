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
namespace CatraProto.Client.TL.Schemas.MTProto
{
    public partial class ClientDHInnerData : CatraProto.Client.TL.Schemas.MTProto.ClientDHInnerDataBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1715713620; }

        [Newtonsoft.Json.JsonProperty("nonce")]
        public sealed override System.Numerics.BigInteger Nonce { get; set; }

        [Newtonsoft.Json.JsonProperty("server_nonce")]
        public sealed override System.Numerics.BigInteger ServerNonce { get; set; }

        [Newtonsoft.Json.JsonProperty("retry_id")]
        public sealed override long RetryId { get; set; }

        [Newtonsoft.Json.JsonProperty("g_b")]
        public sealed override byte[] GB { get; set; }


#nullable enable
        public ClientDHInnerData(System.Numerics.BigInteger nonce, System.Numerics.BigInteger serverNonce, long retryId, byte[] gB)
        {
            Nonce = nonce;
            ServerNonce = serverNonce;
            RetryId = retryId;
            GB = gB;

        }
#nullable disable
        internal ClientDHInnerData()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkNonce = writer.WriteBigInteger(Nonce);
            if (checkNonce.IsError) { return checkNonce; }
            var checkServerNonce = writer.WriteBigInteger(ServerNonce);
            if (checkServerNonce.IsError) { return checkServerNonce; }
            writer.WriteInt64(RetryId);

            writer.WriteBytes(GB);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trynonce = reader.ReadBigInteger(128);
            if (trynonce.IsError)
            {
                return ReadResult<IObject>.Move(trynonce);
            }
            Nonce = trynonce.Value;
            var tryserverNonce = reader.ReadBigInteger(128);
            if (tryserverNonce.IsError)
            {
                return ReadResult<IObject>.Move(tryserverNonce);
            }
            ServerNonce = tryserverNonce.Value;
            var tryretryId = reader.ReadInt64();
            if (tryretryId.IsError)
            {
                return ReadResult<IObject>.Move(tryretryId);
            }
            RetryId = tryretryId.Value;
            var trygB = reader.ReadBytes();
            if (trygB.IsError)
            {
                return ReadResult<IObject>.Move(trygB);
            }
            GB = trygB.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "client_DH_inner_data";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new ClientDHInnerData
            {
                Nonce = Nonce,
                ServerNonce = ServerNonce,
                RetryId = RetryId,
                GB = GB
            };
            return newClonedObject;

        }
#nullable disable
    }
}