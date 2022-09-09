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
    public partial class SentEmailCode : CatraProto.Client.TL.Schemas.CloudChats.Account.SentEmailCodeBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -2128640689; }

        [Newtonsoft.Json.JsonProperty("email_pattern")]
        public sealed override string EmailPattern { get; set; }

        [Newtonsoft.Json.JsonProperty("length")]
        public sealed override int Length { get; set; }


#nullable enable
        public SentEmailCode(string emailPattern, int length)
        {
            EmailPattern = emailPattern;
            Length = length;
        }
#nullable disable
        internal SentEmailCode()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(EmailPattern);
            writer.WriteInt32(Length);

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
            var trylength = reader.ReadInt32();
            if (trylength.IsError)
            {
                return ReadResult<IObject>.Move(trylength);
            }

            Length = trylength.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "account.sentEmailCode";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new SentEmailCode();
            newClonedObject.EmailPattern = EmailPattern;
            newClonedObject.Length = Length;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not SentEmailCode castedOther)
            {
                return true;
            }

            if (EmailPattern != castedOther.EmailPattern)
            {
                return true;
            }

            if (Length != castedOther.Length)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}