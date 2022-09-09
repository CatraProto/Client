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
    public partial class FutureSalt : CatraProto.Client.TL.Schemas.MTProto.FutureSaltBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 155834844; }

        [Newtonsoft.Json.JsonProperty("valid_since")]
        public sealed override int ValidSince { get; set; }

        [Newtonsoft.Json.JsonProperty("valid_until")]
        public sealed override int ValidUntil { get; set; }

        [Newtonsoft.Json.JsonProperty("salt")] public sealed override long Salt { get; set; }


#nullable enable
        public FutureSalt(int validSince, int validUntil, long salt)
        {
            ValidSince = validSince;
            ValidUntil = validUntil;
            Salt = salt;
        }
#nullable disable
        internal FutureSalt()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt32(ValidSince);
            writer.WriteInt32(ValidUntil);
            writer.WriteInt64(Salt);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryvalidSince = reader.ReadInt32();
            if (tryvalidSince.IsError)
            {
                return ReadResult<IObject>.Move(tryvalidSince);
            }

            ValidSince = tryvalidSince.Value;
            var tryvalidUntil = reader.ReadInt32();
            if (tryvalidUntil.IsError)
            {
                return ReadResult<IObject>.Move(tryvalidUntil);
            }

            ValidUntil = tryvalidUntil.Value;
            var trysalt = reader.ReadInt64();
            if (trysalt.IsError)
            {
                return ReadResult<IObject>.Move(trysalt);
            }

            Salt = trysalt.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "future_salt";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new FutureSalt();
            newClonedObject.ValidSince = ValidSince;
            newClonedObject.ValidUntil = ValidUntil;
            newClonedObject.Salt = Salt;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not FutureSalt castedOther)
            {
                return true;
            }

            if (ValidSince != castedOther.ValidSince)
            {
                return true;
            }

            if (ValidUntil != castedOther.ValidUntil)
            {
                return true;
            }

            if (Salt != castedOther.Salt)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}