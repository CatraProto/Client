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
    public partial class LangPackString : CatraProto.Client.TL.Schemas.CloudChats.LangPackStringBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -892239370; }

        [Newtonsoft.Json.JsonProperty("key")] public sealed override string Key { get; set; }

        [Newtonsoft.Json.JsonProperty("value")]
        public string Value { get; set; }


#nullable enable
        public LangPackString(string key, string value)
        {
            Key = key;
            Value = value;
        }
#nullable disable
        internal LangPackString()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(Key);

            writer.WriteString(Value);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trykey = reader.ReadString();
            if (trykey.IsError)
            {
                return ReadResult<IObject>.Move(trykey);
            }

            Key = trykey.Value;
            var tryvalue = reader.ReadString();
            if (tryvalue.IsError)
            {
                return ReadResult<IObject>.Move(tryvalue);
            }

            Value = tryvalue.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "langPackString";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new LangPackString();
            newClonedObject.Key = Key;
            newClonedObject.Value = Value;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not LangPackString castedOther)
            {
                return true;
            }

            if (Key != castedOther.Key)
            {
                return true;
            }

            if (Value != castedOther.Value)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}