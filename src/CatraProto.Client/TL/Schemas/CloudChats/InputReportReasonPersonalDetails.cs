using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class InputReportReasonPersonalDetails : CatraProto.Client.TL.Schemas.CloudChats.ReportReasonBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1631091139; }



        public InputReportReasonPersonalDetails()
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
            return "inputReportReasonPersonalDetails";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new InputReportReasonPersonalDetails();
            return newClonedObject;

        }

        public override bool Compare(IObject other)
        {
            if (other is not InputReportReasonPersonalDetails castedOther)
            {
                return true;
            }
            return false;

        }

#nullable disable
    }
}