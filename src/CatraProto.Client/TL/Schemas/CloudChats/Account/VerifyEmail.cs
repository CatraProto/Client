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
    public partial class VerifyEmail : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -323339813; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Bool;

        [Newtonsoft.Json.JsonProperty("email")]
        public string Email { get; set; }

        [Newtonsoft.Json.JsonProperty("code")] public string Code { get; set; }


#nullable enable
        public VerifyEmail(string email, string code)
        {
            Email = email;
            Code = code;
        }
#nullable disable

        internal VerifyEmail()
        {
        }

        public void UpdateFlags()
        {
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(Email);

            writer.WriteString(Code);

            return new WriteResult();
        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryemail = reader.ReadString();
            if (tryemail.IsError)
            {
                return ReadResult<IObject>.Move(tryemail);
            }

            Email = tryemail.Value;
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
            return "account.verifyEmail";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new VerifyEmail();
            newClonedObject.Email = Email;
            newClonedObject.Code = Code;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not VerifyEmail castedOther)
            {
                return true;
            }

            if (Email != castedOther.Email)
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