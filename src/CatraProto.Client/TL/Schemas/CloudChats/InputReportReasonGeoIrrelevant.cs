using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class InputReportReasonGeoIrrelevant : CatraProto.Client.TL.Schemas.CloudChats.ReportReasonBase
    {
        public static int StaticConstructorId
        {
            get => -606798099;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }


        public InputReportReasonGeoIrrelevant()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
        }

        public override void Deserialize(Reader reader)
        {
        }

        public override string ToString()
        {
            return "inputReportReasonGeoIrrelevant";
        }
    }
}