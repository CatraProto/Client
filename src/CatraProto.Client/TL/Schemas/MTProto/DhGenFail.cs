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
    public partial class DhGenFail : CatraProto.Client.TL.Schemas.MTProto.SetClientDHParamsAnswerBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1499615742; }

        [Newtonsoft.Json.JsonProperty("nonce")]
        public sealed override System.Numerics.BigInteger Nonce { get; set; }

        [Newtonsoft.Json.JsonProperty("server_nonce")]
        public sealed override System.Numerics.BigInteger ServerNonce { get; set; }

        [Newtonsoft.Json.JsonProperty("new_nonce_hash3")]
        public System.Numerics.BigInteger NewNonceHash3 { get; set; }


#nullable enable
        public DhGenFail(System.Numerics.BigInteger nonce, System.Numerics.BigInteger serverNonce, System.Numerics.BigInteger newNonceHash3)
        {
            Nonce = nonce;
            ServerNonce = serverNonce;
            NewNonceHash3 = newNonceHash3;

        }
#nullable disable
        internal DhGenFail()
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
            var checkNewNonceHash3 = writer.WriteBigInteger(NewNonceHash3);
            if (checkNewNonceHash3.IsError) { return checkNewNonceHash3; }

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
            var trynewNonceHash3 = reader.ReadBigInteger(128);
            if (trynewNonceHash3.IsError)
            {
                return ReadResult<IObject>.Move(trynewNonceHash3);
            }
            NewNonceHash3 = trynewNonceHash3.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "dh_gen_fail";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new DhGenFail
            {
                Nonce = Nonce,
                ServerNonce = ServerNonce,
                NewNonceHash3 = NewNonceHash3
            };
            return newClonedObject;

        }

        public override bool Compare(IObject other)
        {
            if (other is not DhGenFail castedOther)
            {
                return true;
            }
            if (Nonce != castedOther.Nonce)
            {
                return true;
            }
            if (ServerNonce != castedOther.ServerNonce)
            {
                return true;
            }
            if (NewNonceHash3 != castedOther.NewNonceHash3)
            {
                return true;
            }
            return false;

        }

#nullable disable
    }
}