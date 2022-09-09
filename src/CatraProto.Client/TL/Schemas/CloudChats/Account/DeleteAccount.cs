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
    public partial class DeleteAccount : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 1099779595; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Bool;

        [Newtonsoft.Json.JsonProperty("reason")]
        public string Reason { get; set; }


#nullable enable
        public DeleteAccount(string reason)
        {
            Reason = reason;
        }
#nullable disable

        internal DeleteAccount()
        {
        }

        public void UpdateFlags()
        {
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(Reason);

            return new WriteResult();
        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryreason = reader.ReadString();
            if (tryreason.IsError)
            {
                return ReadResult<IObject>.Move(tryreason);
            }

            Reason = tryreason.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "account.deleteAccount";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new DeleteAccount();
            newClonedObject.Reason = Reason;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not DeleteAccount castedOther)
            {
                return true;
            }

            if (Reason != castedOther.Reason)
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}