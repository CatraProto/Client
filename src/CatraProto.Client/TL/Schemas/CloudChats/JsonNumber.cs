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
    public partial class JsonNumber : CatraProto.Client.TL.Schemas.CloudChats.JSONValueBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 736157604; }

        [Newtonsoft.Json.JsonProperty("value")]
        public double Value { get; set; }


#nullable enable
        public JsonNumber(double value)
        {
            Value = value;
        }
#nullable disable
        internal JsonNumber()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteDouble(Value);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryvalue = reader.ReadDouble();
            if (tryvalue.IsError)
            {
                return ReadResult<IObject>.Move(tryvalue);
            }

            Value = tryvalue.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "jsonNumber";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new JsonNumber();
            newClonedObject.Value = Value;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not JsonNumber castedOther)
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