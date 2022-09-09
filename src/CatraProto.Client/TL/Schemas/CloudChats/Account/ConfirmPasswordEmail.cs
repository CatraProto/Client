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
    public partial class ConfirmPasswordEmail : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1881204448; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Bool;

        [Newtonsoft.Json.JsonProperty("code")] public string Code { get; set; }


#nullable enable
        public ConfirmPasswordEmail(string code)
        {
            Code = code;
        }
#nullable disable

        internal ConfirmPasswordEmail()
        {
        }

        public void UpdateFlags()
        {
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(Code);

            return new WriteResult();
        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var trycode = reader.ReadString();
            if (trycode.IsError)
            {
                return ReadResult<IObject>.Move(trycode);
            }

            Code = trycode.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "account.confirmPasswordEmail";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new ConfirmPasswordEmail();
            newClonedObject.Code = Code;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not ConfirmPasswordEmail castedOther)
            {
                return true;
            }

            if (Code != castedOther.Code)
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}