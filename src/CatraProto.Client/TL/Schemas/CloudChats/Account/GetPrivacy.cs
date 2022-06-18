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
    public partial class GetPrivacy : IMethod
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -623130288; }

        [Newtonsoft.Json.JsonIgnore]
        ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("key")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputPrivacyKeyBase Key { get; set; }


#nullable enable
        public GetPrivacy(CatraProto.Client.TL.Schemas.CloudChats.InputPrivacyKeyBase key)
        {
            Key = key;

        }
#nullable disable

        internal GetPrivacy()
        {
        }

        public void UpdateFlags()
        {

        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkkey = writer.WriteObject(Key);
            if (checkkey.IsError)
            {
                return checkkey;
            }

            return new WriteResult();

        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var trykey = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputPrivacyKeyBase>();
            if (trykey.IsError)
            {
                return ReadResult<IObject>.Move(trykey);
            }
            Key = trykey.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "account.getPrivacy";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new GetPrivacy();
            var cloneKey = (CatraProto.Client.TL.Schemas.CloudChats.InputPrivacyKeyBase?)Key.Clone();
            if (cloneKey is null)
            {
                return null;
            }
            newClonedObject.Key = cloneKey;
            return newClonedObject;

        }

        public bool Compare(IObject other)
        {
            if (other is not GetPrivacy castedOther)
            {
                return true;
            }
            if (Key.Compare(castedOther.Key))
            {
                return true;
            }
            return false;

        }
#nullable disable
    }
}