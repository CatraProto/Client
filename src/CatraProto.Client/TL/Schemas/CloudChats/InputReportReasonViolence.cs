using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class InputReportReasonViolence : ReportReasonBase
    {
        public static int ConstructorId { get; } = 505595789;

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
        }

        public override void Deserialize(Reader reader)
        {
        }
    }
}