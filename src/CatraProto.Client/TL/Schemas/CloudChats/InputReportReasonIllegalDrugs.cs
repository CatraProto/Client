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
    public partial class InputReportReasonIllegalDrugs : CatraProto.Client.TL.Schemas.CloudChats.ReportReasonBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 177124030; }


        public InputReportReasonIllegalDrugs()
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
            return "inputReportReasonIllegalDrugs";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new InputReportReasonIllegalDrugs();
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not InputReportReasonIllegalDrugs castedOther)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}