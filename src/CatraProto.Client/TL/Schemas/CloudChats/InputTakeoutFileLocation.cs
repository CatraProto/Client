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
    public partial class InputTakeoutFileLocation : CatraProto.Client.TL.Schemas.CloudChats.InputFileLocationBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 700340377; }


        public InputTakeoutFileLocation()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "inputTakeoutFileLocation";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new InputTakeoutFileLocation();
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not InputTakeoutFileLocation castedOther)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}