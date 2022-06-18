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

using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public partial class SetAccountTTL : IMethod
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 608323678; }

        [Newtonsoft.Json.JsonIgnore]
        ParserTypes IMethod.Type { get; init; } = ParserTypes.Bool;

        [Newtonsoft.Json.JsonProperty("ttl")]
        public CatraProto.Client.TL.Schemas.CloudChats.AccountDaysTTLBase Ttl { get; set; }


#nullable enable
        public SetAccountTTL(CatraProto.Client.TL.Schemas.CloudChats.AccountDaysTTLBase ttl)
        {
            Ttl = ttl;

        }
#nullable disable

        internal SetAccountTTL()
        {
        }

        public void UpdateFlags()
        {

        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkttl = writer.WriteObject(Ttl);
            if (checkttl.IsError)
            {
                return checkttl;
            }

            return new WriteResult();

        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryttl = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.AccountDaysTTLBase>();
            if (tryttl.IsError)
            {
                return ReadResult<IObject>.Move(tryttl);
            }
            Ttl = tryttl.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "account.setAccountTTL";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new SetAccountTTL();
            var cloneTtl = (CatraProto.Client.TL.Schemas.CloudChats.AccountDaysTTLBase?)Ttl.Clone();
            if (cloneTtl is null)
            {
                return null;
            }
            newClonedObject.Ttl = cloneTtl;
            return newClonedObject;

        }

        public bool Compare(IObject other)
        {
            if (other is not SetAccountTTL castedOther)
            {
                return true;
            }
            if (Ttl.Compare(castedOther.Ttl))
            {
                return true;
            }
            return false;

        }
#nullable disable
    }
}