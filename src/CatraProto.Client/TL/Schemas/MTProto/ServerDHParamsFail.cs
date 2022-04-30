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
    public partial class ServerDHParamsFail : CatraProto.Client.TL.Schemas.MTProto.ServerDHParamsBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 2043348061; }

        [Newtonsoft.Json.JsonProperty("nonce")]
        public sealed override System.Numerics.BigInteger Nonce { get; set; }

        [Newtonsoft.Json.JsonProperty("server_nonce")]
        public sealed override System.Numerics.BigInteger ServerNonce { get; set; }

        [Newtonsoft.Json.JsonProperty("new_nonce_hash")]
        public System.Numerics.BigInteger NewNonceHash { get; set; }


#nullable enable
        public ServerDHParamsFail(System.Numerics.BigInteger nonce, System.Numerics.BigInteger serverNonce, System.Numerics.BigInteger newNonceHash)
        {
            Nonce = nonce;
            ServerNonce = serverNonce;
            NewNonceHash = newNonceHash;

        }
#nullable disable
        internal ServerDHParamsFail()
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
            var checkNewNonceHash = writer.WriteBigInteger(NewNonceHash);
            if (checkNewNonceHash.IsError) { return checkNewNonceHash; }

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
            var trynewNonceHash = reader.ReadBigInteger(128);
            if (trynewNonceHash.IsError)
            {
                return ReadResult<IObject>.Move(trynewNonceHash);
            }
            NewNonceHash = trynewNonceHash.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "server_DH_params_fail";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new ServerDHParamsFail
            {
                Nonce = Nonce,
                ServerNonce = ServerNonce,
                NewNonceHash = NewNonceHash
            };
            return newClonedObject;

        }
#nullable disable
    }
}