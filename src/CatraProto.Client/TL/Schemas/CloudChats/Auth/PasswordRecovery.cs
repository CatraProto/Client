using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Auth
{
    public partial class PasswordRecovery : CatraProto.Client.TL.Schemas.CloudChats.Auth.PasswordRecoveryBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 326715557; }

        [Newtonsoft.Json.JsonProperty("email_pattern")]
        public sealed override string EmailPattern { get; set; }


#nullable enable
        public PasswordRecovery(string emailPattern)
        {
            EmailPattern = emailPattern;
        }
#nullable disable
        internal PasswordRecovery()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(EmailPattern);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryemailPattern = reader.ReadString();
            if (tryemailPattern.IsError)
            {
                return ReadResult<IObject>.Move(tryemailPattern);
            }

            EmailPattern = tryemailPattern.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "auth.passwordRecovery";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new PasswordRecovery();
            newClonedObject.EmailPattern = EmailPattern;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not PasswordRecovery castedOther)
            {
                return true;
            }

            if (EmailPattern != castedOther.EmailPattern)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}