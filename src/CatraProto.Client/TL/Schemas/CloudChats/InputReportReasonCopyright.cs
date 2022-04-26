using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class InputReportReasonCopyright : CatraProto.Client.TL.Schemas.CloudChats.ReportReasonBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1685456582; }



        public InputReportReasonCopyright()
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
            return "inputReportReasonCopyright";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new InputReportReasonCopyright();
            return newClonedObject;

        }
#nullable disable
    }
}