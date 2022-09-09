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
    public partial class SendVerifyEmailCode : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 1880182943; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("email")]
        public string Email { get; set; }


#nullable enable
        public SendVerifyEmailCode(string email)
        {
            Email = email;
        }
#nullable disable

        internal SendVerifyEmailCode()
        {
        }

        public void UpdateFlags()
        {
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(Email);

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
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "account.sendVerifyEmailCode";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new SendVerifyEmailCode();
            newClonedObject.Email = Email;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not SendVerifyEmailCode castedOther)
            {
                return true;
            }

            if (Email != castedOther.Email)
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}