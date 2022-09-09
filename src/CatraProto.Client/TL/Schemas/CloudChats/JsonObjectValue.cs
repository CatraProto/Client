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
    public partial class JsonObjectValue : CatraProto.Client.TL.Schemas.CloudChats.JSONObjectValueBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1059185703; }

        [Newtonsoft.Json.JsonProperty("key")] public sealed override string Key { get; set; }

        [Newtonsoft.Json.JsonProperty("value")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.JSONValueBase Value { get; set; }


#nullable enable
        public JsonObjectValue(string key, CatraProto.Client.TL.Schemas.CloudChats.JSONValueBase value)
        {
            Key = key;
            Value = value;
        }
#nullable disable
        internal JsonObjectValue()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(Key);
            var checkvalue = writer.WriteObject(Value);
            if (checkvalue.IsError)
            {
                return checkvalue;
            }

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
            var tryvalue = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.JSONValueBase>();
            if (tryvalue.IsError)
            {
                return ReadResult<IObject>.Move(tryvalue);
            }

            Value = tryvalue.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "jsonObjectValue";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new JsonObjectValue();
            newClonedObject.Key = Key;
            var cloneValue = (CatraProto.Client.TL.Schemas.CloudChats.JSONValueBase?)Value.Clone();
            if (cloneValue is null)
            {
                return null;
            }

            newClonedObject.Value = cloneValue;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not JsonObjectValue castedOther)
            {
                return true;
            }

            if (Key != castedOther.Key)
            {
                return true;
            }

            if (Value.Compare(castedOther.Value))
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}