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

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public partial class SetPrivacy : IMethod
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -906486552; }

        [Newtonsoft.Json.JsonIgnore]
        ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("key")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputPrivacyKeyBase Key { get; set; }

        [Newtonsoft.Json.JsonProperty("rules")]
        public List<CatraProto.Client.TL.Schemas.CloudChats.InputPrivacyRuleBase> Rules { get; set; }


#nullable enable
        public SetPrivacy(CatraProto.Client.TL.Schemas.CloudChats.InputPrivacyKeyBase key, List<CatraProto.Client.TL.Schemas.CloudChats.InputPrivacyRuleBase> rules)
        {
            Key = key;
            Rules = rules;

        }
#nullable disable

        internal SetPrivacy()
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
            var checkrules = writer.WriteVector(Rules, false);
            if (checkrules.IsError)
            {
                return checkrules;
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
            var tryrules = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.InputPrivacyRuleBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (tryrules.IsError)
            {
                return ReadResult<IObject>.Move(tryrules);
            }
            Rules = tryrules.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "account.setPrivacy";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new SetPrivacy();
            var cloneKey = (CatraProto.Client.TL.Schemas.CloudChats.InputPrivacyKeyBase?)Key.Clone();
            if (cloneKey is null)
            {
                return null;
            }
            newClonedObject.Key = cloneKey;
            newClonedObject.Rules = new List<CatraProto.Client.TL.Schemas.CloudChats.InputPrivacyRuleBase>();
            foreach (var rules in Rules)
            {
                var clonerules = (CatraProto.Client.TL.Schemas.CloudChats.InputPrivacyRuleBase?)rules.Clone();
                if (clonerules is null)
                {
                    return null;
                }
                newClonedObject.Rules.Add(clonerules);
            }
            return newClonedObject;

        }

        public bool Compare(IObject other)
        {
            if (other is not SetPrivacy castedOther)
            {
                return true;
            }
            if (Key.Compare(castedOther.Key))
            {
                return true;
            }
            var rulessize = castedOther.Rules.Count;
            if (rulessize != Rules.Count)
            {
                return true;
            }
            for (var i = 0; i < rulessize; i++)
            {
                if (castedOther.Rules[i].Compare(Rules[i]))
                {
                    return true;
                }
            }
            return false;

        }
#nullable disable
    }
}