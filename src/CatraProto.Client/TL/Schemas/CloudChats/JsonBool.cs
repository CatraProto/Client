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
    public partial class JsonBool : CatraProto.Client.TL.Schemas.CloudChats.JSONValueBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -952869270; }

        [Newtonsoft.Json.JsonProperty("value")]
        public bool Value { get; set; }


#nullable enable
        public JsonBool(bool value)
        {
            Value = value;
        }
#nullable disable
        internal JsonBool()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkvalue = writer.WriteBool(Value);
            if (checkvalue.IsError)
            {
                return checkvalue;
            }

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryvalue = reader.ReadBool();
            if (tryvalue.IsError)
            {
                return ReadResult<IObject>.Move(tryvalue);
            }

            Value = tryvalue.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "jsonBool";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new JsonBool();
            newClonedObject.Value = Value;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not JsonBool castedOther)
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