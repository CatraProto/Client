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
    public partial class JsonString : CatraProto.Client.TL.Schemas.CloudChats.JSONValueBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1222740358; }

        [Newtonsoft.Json.JsonProperty("value")]
        public string Value { get; set; }


#nullable enable
        public JsonString(string value)
        {
            Value = value;
        }
#nullable disable
        internal JsonString()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(Value);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
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
            return "jsonString";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new JsonString();
            newClonedObject.Value = Value;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not JsonString castedOther)
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