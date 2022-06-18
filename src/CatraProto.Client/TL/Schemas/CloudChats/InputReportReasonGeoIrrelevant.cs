using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class InputReportReasonGeoIrrelevant : CatraProto.Client.TL.Schemas.CloudChats.ReportReasonBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -606798099; }



        public InputReportReasonGeoIrrelevant()
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
            return "inputReportReasonGeoIrrelevant";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new InputReportReasonGeoIrrelevant();
            return newClonedObject;

        }

        public override bool Compare(IObject other)
        {
            if (other is not InputReportReasonGeoIrrelevant castedOther)
            {
                return true;
            }
            return false;

        }

#nullable disable
    }
}