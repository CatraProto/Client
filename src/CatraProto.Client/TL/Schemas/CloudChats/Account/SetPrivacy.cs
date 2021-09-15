using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public partial class SetPrivacy : IMethod
    {
        [JsonIgnore]
        public static int StaticConstructorId
        {
            get => -906486552;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(PrivacyRulesBase);

        [JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [JsonProperty("key")] public InputPrivacyKeyBase Key { get; set; }

        [JsonProperty("rules")] public IList<InputPrivacyRuleBase> Rules { get; set; }

        public override string ToString()
        {
            return "account.setPrivacy";
        }


        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            writer.Write(Key);
            writer.Write(Rules);
        }

        public void Deserialize(Reader reader)
        {
            Key = reader.Read<InputPrivacyKeyBase>();
            Rules = reader.ReadVector<InputPrivacyRuleBase>();
        }
    }
}