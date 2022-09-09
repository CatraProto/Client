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
    public partial class ConfirmPhone : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 1596029123; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Bool;

        [Newtonsoft.Json.JsonProperty("phone_code_hash")]
        public string PhoneCodeHash { get; set; }

        [Newtonsoft.Json.JsonProperty("phone_code")]
        public string PhoneCode { get; set; }


#nullable enable
        public ConfirmPhone(string phoneCodeHash, string phoneCode)
        {
            PhoneCodeHash = phoneCodeHash;
            PhoneCode = phoneCode;
        }
#nullable disable

        internal ConfirmPhone()
        {
        }

        public void UpdateFlags()
        {
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(PhoneCodeHash);

            writer.WriteString(PhoneCode);

            return new WriteResult();
        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryphoneCodeHash = reader.ReadString();
            if (tryphoneCodeHash.IsError)
            {
                return ReadResult<IObject>.Move(tryphoneCodeHash);
            }

            PhoneCodeHash = tryphoneCodeHash.Value;
            var tryphoneCode = reader.ReadString();
            if (tryphoneCode.IsError)
            {
                return ReadResult<IObject>.Move(tryphoneCode);
            }

            PhoneCode = tryphoneCode.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "account.confirmPhone";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new ConfirmPhone();
            newClonedObject.PhoneCodeHash = PhoneCodeHash;
            newClonedObject.PhoneCode = PhoneCode;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not ConfirmPhone castedOther)
            {
                return true;
            }

            if (PhoneCodeHash != castedOther.PhoneCodeHash)
            {
                return true;
            }

            if (PhoneCode != castedOther.PhoneCode)
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}