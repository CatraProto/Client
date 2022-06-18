/*
CatraProto, a C# library that implements the MTProto protocol and the Telegram API.
Copyright (C) 2022 Aquatica <aquathing@protonmail.com>

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Lesser General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Lesser General Public License for more details.

You should have received a copy of the GNU Lesser General Public License
along with this program.  If not, see <https://www.gnu.org/licenses/>.
*/

using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Contacts
{
    public partial class DeleteByPhones : IMethod
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 269745566; }

        [Newtonsoft.Json.JsonIgnore]
        ParserTypes IMethod.Type { get; init; } = ParserTypes.Bool;

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
            var newClonedObject = new DeleteByPhones
            {
                Phones = new List<string>()
            };
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