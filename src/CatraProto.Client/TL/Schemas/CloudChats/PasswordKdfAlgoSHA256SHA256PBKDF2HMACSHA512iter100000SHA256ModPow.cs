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
    public partial class PasswordKdfAlgoSHA256SHA256PBKDF2HMACSHA512iter100000SHA256ModPow : CatraProto.Client.TL.Schemas.CloudChats.PasswordKdfAlgoBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 982592842; }

        [Newtonsoft.Json.JsonProperty("salt1")]
        public byte[] Salt1 { get; set; }

        [Newtonsoft.Json.JsonProperty("salt2")]
        public byte[] Salt2 { get; set; }

        [Newtonsoft.Json.JsonProperty("g")] public int G { get; set; }

        [Newtonsoft.Json.JsonProperty("p")] public byte[] P { get; set; }


#nullable enable
        public PasswordKdfAlgoSHA256SHA256PBKDF2HMACSHA512iter100000SHA256ModPow(byte[] salt1, byte[] salt2, int g, byte[] p)
        {
            Salt1 = salt1;
            Salt2 = salt2;
            G = g;
            P = p;
        }
#nullable disable
        internal PasswordKdfAlgoSHA256SHA256PBKDF2HMACSHA512iter100000SHA256ModPow()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteBytes(Salt1);

            writer.WriteBytes(Salt2);
            writer.WriteInt32(G);

            writer.WriteBytes(P);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trysalt1 = reader.ReadBytes();
            if (trysalt1.IsError)
            {
                return ReadResult<IObject>.Move(trysalt1);
            }

            Salt1 = trysalt1.Value;
            var trysalt2 = reader.ReadBytes();
            if (trysalt2.IsError)
            {
                return ReadResult<IObject>.Move(trysalt2);
            }

            Salt2 = trysalt2.Value;
            var tryg = reader.ReadInt32();
            if (tryg.IsError)
            {
                return ReadResult<IObject>.Move(tryg);
            }

            G = tryg.Value;
            var tryp = reader.ReadBytes();
            if (tryp.IsError)
            {
                return ReadResult<IObject>.Move(tryp);
            }

            P = tryp.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "passwordKdfAlgoSHA256SHA256PBKDF2HMACSHA512iter100000SHA256ModPow";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new PasswordKdfAlgoSHA256SHA256PBKDF2HMACSHA512iter100000SHA256ModPow();
            newClonedObject.Salt1 = Salt1;
            newClonedObject.Salt2 = Salt2;
            newClonedObject.G = G;
            newClonedObject.P = P;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not PasswordKdfAlgoSHA256SHA256PBKDF2HMACSHA512iter100000SHA256ModPow castedOther)
            {
                return true;
            }

            if (Salt1 != castedOther.Salt1)
            {
                return true;
            }

            if (Salt2 != castedOther.Salt2)
            {
                return true;
            }

            if (G != castedOther.G)
            {
                return true;
            }

            if (P != castedOther.P)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}