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
    public partial class DataJSON : CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 2104790276; }

        [Newtonsoft.Json.JsonProperty("data")] public sealed override string Data { get; set; }


#nullable enable
        public DataJSON(string data)
        {
            Data = data;
        }
#nullable disable
        internal DataJSON()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(Data);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trydata = reader.ReadString();
            if (trydata.IsError)
            {
                return ReadResult<IObject>.Move(trydata);
            }

            Data = trydata.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "dataJSON";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new DataJSON();
            newClonedObject.Data = Data;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not DataJSON castedOther)
            {
                return true;
            }

            if (Data != castedOther.Data)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}