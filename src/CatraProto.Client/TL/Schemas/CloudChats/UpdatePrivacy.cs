using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class UpdatePrivacy : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -298113238; }

        [Newtonsoft.Json.JsonProperty("key")] public CatraProto.Client.TL.Schemas.CloudChats.PrivacyKeyBase Key { get; set; }

        [Newtonsoft.Json.JsonProperty("rules")]
        public List<CatraProto.Client.TL.Schemas.CloudChats.PrivacyRuleBase> Rules { get; set; }


#nullable enable
        public UpdatePrivacy(CatraProto.Client.TL.Schemas.CloudChats.PrivacyKeyBase key, List<CatraProto.Client.TL.Schemas.CloudChats.PrivacyRuleBase> rules)
        {
            Key = key;
            Rules = rules;
        }
#nullable disable
        internal UpdatePrivacy()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
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

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trykey = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.PrivacyKeyBase>();
            if (trykey.IsError)
            {
                return ReadResult<IObject>.Move(trykey);
            }

            Key = trykey.Value;
            var tryrules = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.PrivacyRuleBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (tryrules.IsError)
            {
                return ReadResult<IObject>.Move(tryrules);
            }

            Rules = tryrules.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "updatePrivacy";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new UpdatePrivacy();
            var cloneKey = (CatraProto.Client.TL.Schemas.CloudChats.PrivacyKeyBase?)Key.Clone();
            if (cloneKey is null)
            {
                return null;
            }

            newClonedObject.Key = cloneKey;
            newClonedObject.Rules = new List<CatraProto.Client.TL.Schemas.CloudChats.PrivacyRuleBase>();
            foreach (var rules in Rules)
            {
                var clonerules = (CatraProto.Client.TL.Schemas.CloudChats.PrivacyRuleBase?)rules.Clone();
                if (clonerules is null)
                {
                    return null;
                }

                newClonedObject.Rules.Add(clonerules);
            }

            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not UpdatePrivacy castedOther)
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