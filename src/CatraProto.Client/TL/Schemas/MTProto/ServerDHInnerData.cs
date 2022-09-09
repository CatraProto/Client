using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.MTProto
{
    public partial class ServerDHInnerData : CatraProto.Client.TL.Schemas.MTProto.ServerDHInnerDataBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1249309254; }

        [Newtonsoft.Json.JsonProperty("nonce")]
        public sealed override System.Numerics.BigInteger Nonce { get; set; }

        [Newtonsoft.Json.JsonProperty("server_nonce")]
        public sealed override System.Numerics.BigInteger ServerNonce { get; set; }

        [Newtonsoft.Json.JsonProperty("g")] public sealed override int G { get; set; }

        [Newtonsoft.Json.JsonProperty("dh_prime")]
        public sealed override byte[] DhPrime { get; set; }

        [Newtonsoft.Json.JsonProperty("g_a")] public sealed override byte[] GA { get; set; }

        [Newtonsoft.Json.JsonProperty("server_time")]
        public sealed override int ServerTime { get; set; }


#nullable enable
        public ServerDHInnerData(System.Numerics.BigInteger nonce, System.Numerics.BigInteger serverNonce, int g, byte[] dhPrime, byte[] gA, int serverTime)
        {
            Nonce = nonce;
            ServerNonce = serverNonce;
            G = g;
            DhPrime = dhPrime;
            GA = gA;
            ServerTime = serverTime;
        }
#nullable disable
        internal ServerDHInnerData()
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

            writer.WriteInt32(G);

            writer.WriteBytes(DhPrime);

            writer.WriteBytes(GA);
            writer.WriteInt32(ServerTime);

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
            var tryg = reader.ReadInt32();
            if (tryg.IsError)
            {
                return ReadResult<IObject>.Move(tryg);
            }

            G = tryg.Value;
            var trydhPrime = reader.ReadBytes();
            if (trydhPrime.IsError)
            {
                return ReadResult<IObject>.Move(trydhPrime);
            }

            DhPrime = trydhPrime.Value;
            var trygA = reader.ReadBytes();
            if (trygA.IsError)
            {
                return ReadResult<IObject>.Move(trygA);
            }

            GA = trygA.Value;
            var tryserverTime = reader.ReadInt32();
            if (tryserverTime.IsError)
            {
                return ReadResult<IObject>.Move(tryserverTime);
            }

            ServerTime = tryserverTime.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "server_DH_inner_data";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new ServerDHInnerData();
            newClonedObject.Nonce = Nonce;
            newClonedObject.ServerNonce = ServerNonce;
            newClonedObject.G = G;
            newClonedObject.DhPrime = DhPrime;
            newClonedObject.GA = GA;
            newClonedObject.ServerTime = ServerTime;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not ServerDHInnerData castedOther)
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

            if (G != castedOther.G)
            {
                return true;
            }

            if (DhPrime != castedOther.DhPrime)
            {
                return true;
            }

            if (GA != castedOther.GA)
            {
                return true;
            }

            if (ServerTime != castedOther.ServerTime)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}