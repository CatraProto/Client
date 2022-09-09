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
    public partial class SetPrivacy : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -906486552; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("key")] public CatraProto.Client.TL.Schemas.CloudChats.InputPrivacyKeyBase Key { get; set; }

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