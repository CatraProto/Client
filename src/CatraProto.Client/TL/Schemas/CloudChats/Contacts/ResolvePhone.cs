using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Contacts
{
    public partial class ResolvePhone : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1963375804; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("phone")]
        public string Phone { get; set; }


#nullable enable
        public ResolvePhone(string phone)
        {
            Phone = phone;
        }
#nullable disable

        internal ResolvePhone()
        {
        }

        public void UpdateFlags()
        {
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(Phone);

            return new WriteResult();
        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryphone = reader.ReadString();
            if (tryphone.IsError)
            {
                return ReadResult<IObject>.Move(tryphone);
            }

            Phone = tryphone.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "contacts.resolvePhone";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new ResolvePhone();
            newClonedObject.Phone = Phone;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not ResolvePhone castedOther)
            {
                return true;
            }

            if (Phone != castedOther.Phone)
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}