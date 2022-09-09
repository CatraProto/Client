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
    public partial class StatsGraphError : CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1092839390; }

        [Newtonsoft.Json.JsonProperty("error")]
        public string Error { get; set; }


#nullable enable
        public StatsGraphError(string error)
        {
            Error = error;
        }
#nullable disable
        internal StatsGraphError()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(Error);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryerror = reader.ReadString();
            if (tryerror.IsError)
            {
                return ReadResult<IObject>.Move(tryerror);
            }

            Error = tryerror.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "statsGraphError";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new StatsGraphError();
            newClonedObject.Error = Error;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not StatsGraphError castedOther)
            {
                return true;
            }

            if (Error != castedOther.Error)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}