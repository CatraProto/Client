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

using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.MTProto
{
    public partial class ResPQ : CatraProto.Client.TL.Schemas.MTProto.ResPQBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 85337187; }

        [Newtonsoft.Json.JsonProperty("nonce")]
        public sealed override System.Numerics.BigInteger Nonce { get; set; }

        [Newtonsoft.Json.JsonProperty("server_nonce")]
        public sealed override System.Numerics.BigInteger ServerNonce { get; set; }

        [Newtonsoft.Json.JsonProperty("pq")]
        public sealed override byte[] Pq { get; set; }

        [Newtonsoft.Json.JsonProperty("server_public_key_fingerprints")]
        public sealed override List<long> ServerPublicKeyFingerprints { get; set; }


#nullable enable
        public ResPQ(System.Numerics.BigInteger nonce, System.Numerics.BigInteger serverNonce, byte[] pq, List<long> serverPublicKeyFingerprints)
        {
            Nonce = nonce;
            ServerNonce = serverNonce;
            Pq = pq;
            ServerPublicKeyFingerprints = serverPublicKeyFingerprints;

        }
#nullable disable
        internal ResPQ()
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

            writer.WriteBytes(Pq);

            writer.WriteVector(ServerPublicKeyFingerprints, false);

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
            var trypq = reader.ReadBytes();
            if (trypq.IsError)
            {
                return ReadResult<IObject>.Move(trypq);
            }
            Pq = trypq.Value;
            var tryserverPublicKeyFingerprints = reader.ReadVector<long>(ParserTypes.Int64);
            if (tryserverPublicKeyFingerprints.IsError)
            {
                return ReadResult<IObject>.Move(tryserverPublicKeyFingerprints);
            }
            ServerPublicKeyFingerprints = tryserverPublicKeyFingerprints.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "resPQ";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new ResPQ
            {
                Nonce = Nonce,
                ServerNonce = ServerNonce,
                Pq = Pq,
                ServerPublicKeyFingerprints = new List<long>()
            };
            foreach (var serverPublicKeyFingerprints in ServerPublicKeyFingerprints)
            {
                newClonedObject.ServerPublicKeyFingerprints.Add(serverPublicKeyFingerprints);
            }
            return newClonedObject;

        }
#nullable disable
    }
}