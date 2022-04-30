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
    public partial class ServerDHParamsOk : CatraProto.Client.TL.Schemas.MTProto.ServerDHParamsBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -790100132; }

        [Newtonsoft.Json.JsonProperty("nonce")]
        public sealed override System.Numerics.BigInteger Nonce { get; set; }

        [Newtonsoft.Json.JsonProperty("server_nonce")]
        public sealed override System.Numerics.BigInteger ServerNonce { get; set; }

        [Newtonsoft.Json.JsonProperty("encrypted_answer")]
        public byte[] EncryptedAnswer { get; set; }


#nullable enable
        public ServerDHParamsOk(System.Numerics.BigInteger nonce, System.Numerics.BigInteger serverNonce, byte[] encryptedAnswer)
        {
            Nonce = nonce;
            ServerNonce = serverNonce;
            EncryptedAnswer = encryptedAnswer;

        }
#nullable disable
        internal ServerDHParamsOk()
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

            writer.WriteBytes(EncryptedAnswer);

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
            var tryencryptedAnswer = reader.ReadBytes();
            if (tryencryptedAnswer.IsError)
            {
                return ReadResult<IObject>.Move(tryencryptedAnswer);
            }
            EncryptedAnswer = tryencryptedAnswer.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "server_DH_params_ok";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new ServerDHParamsOk
            {
                Nonce = Nonce,
                ServerNonce = ServerNonce,
                EncryptedAnswer = EncryptedAnswer
            };
            return newClonedObject;

        }
#nullable disable
    }
}