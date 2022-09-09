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
    public partial class DeleteByPhones : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 269745566; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Bool;

        [Newtonsoft.Json.JsonProperty("phones")]
        public List<string> Phones { get; set; }


#nullable enable
        public DeleteByPhones(List<string> phones)
        {
            Phones = phones;
        }
#nullable disable

        internal DeleteByPhones()
        {
        }

        public void UpdateFlags()
        {
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteVector(Phones, false);

            return new WriteResult();
        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryphones = reader.ReadVector<string>(ParserTypes.String, nakedVector: false, nakedObjects: false);
            if (tryphones.IsError)
            {
                return ReadResult<IObject>.Move(tryphones);
            }

            Phones = tryphones.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "contacts.deleteByPhones";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new DeleteByPhones();
            newClonedObject.Phones = new List<string>();
            foreach (var phones in Phones)
            {
                newClonedObject.Phones.Add(phones);
            }

            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not DeleteByPhones castedOther)
            {
                return true;
            }

            var phonessize = castedOther.Phones.Count;
            if (phonessize != Phones.Count)
            {
                return true;
            }

            for (var i = 0; i < phonessize; i++)
            {
                if (castedOther.Phones[i] != Phones[i])
                {
                    return true;
                }
            }

            return false;
        }
#nullable disable
    }
}