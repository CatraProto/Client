using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public partial class TmpPassword : CatraProto.Client.TL.Schemas.CloudChats.Account.TmpPasswordBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -614138572; }

        [Newtonsoft.Json.JsonProperty("tmp_password")]
        public sealed override byte[] TmpPasswordField { get; set; }

        [Newtonsoft.Json.JsonProperty("valid_until")]
        public sealed override int ValidUntil { get; set; }


#nullable enable
        public TmpPassword(byte[] tmpPasswordField, int validUntil)
        {
            TmpPasswordField = tmpPasswordField;
            ValidUntil = validUntil;
        }
#nullable disable
        internal TmpPassword()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteBytes(TmpPasswordField);
            writer.WriteInt32(ValidUntil);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trytmpPasswordField = reader.ReadBytes();
            if (trytmpPasswordField.IsError)
            {
                return ReadResult<IObject>.Move(trytmpPasswordField);
            }

            TmpPasswordField = trytmpPasswordField.Value;
            var tryvalidUntil = reader.ReadInt32();
            if (tryvalidUntil.IsError)
            {
                return ReadResult<IObject>.Move(tryvalidUntil);
            }

            ValidUntil = tryvalidUntil.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "account.tmpPassword";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new TmpPassword();
            newClonedObject.TmpPasswordField = TmpPasswordField;
            newClonedObject.ValidUntil = ValidUntil;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not TmpPassword castedOther)
            {
                return true;
            }

            if (TmpPasswordField != castedOther.TmpPasswordField)
            {
                return true;
            }

            if (ValidUntil != castedOther.ValidUntil)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}