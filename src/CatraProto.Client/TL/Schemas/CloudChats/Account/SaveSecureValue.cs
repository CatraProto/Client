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
    public partial class SaveSecureValue : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1986010339; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("value")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputSecureValueBase Value { get; set; }

        [Newtonsoft.Json.JsonProperty("secure_secret_id")]
        public long SecureSecretId { get; set; }


#nullable enable
        public SaveSecureValue(CatraProto.Client.TL.Schemas.CloudChats.InputSecureValueBase value, long secureSecretId)
        {
            Value = value;
            SecureSecretId = secureSecretId;
        }
#nullable disable

        internal SaveSecureValue()
        {
        }

        public void UpdateFlags()
        {
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkvalue = writer.WriteObject(Value);
            if (checkvalue.IsError)
            {
                return checkvalue;
            }

            writer.WriteInt64(SecureSecretId);

            return new WriteResult();
        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryvalue = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputSecureValueBase>();
            if (tryvalue.IsError)
            {
                return ReadResult<IObject>.Move(tryvalue);
            }

            Value = tryvalue.Value;
            var trysecureSecretId = reader.ReadInt64();
            if (trysecureSecretId.IsError)
            {
                return ReadResult<IObject>.Move(trysecureSecretId);
            }

            SecureSecretId = trysecureSecretId.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "account.saveSecureValue";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new SaveSecureValue();
            var cloneValue = (CatraProto.Client.TL.Schemas.CloudChats.InputSecureValueBase?)Value.Clone();
            if (cloneValue is null)
            {
                return null;
            }

            newClonedObject.Value = cloneValue;
            newClonedObject.SecureSecretId = SecureSecretId;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not SaveSecureValue castedOther)
            {
                return true;
            }

            if (Value.Compare(castedOther.Value))
            {
                return true;
            }

            if (SecureSecretId != castedOther.SecureSecretId)
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}