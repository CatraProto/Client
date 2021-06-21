using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class StatsDateRangeDays : StatsDateRangeDaysBase
    {
        public static int ConstructorId { get; } = -1237848657;
        public override int MinDate { get; set; }
        public override int MaxDate { get; set; }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            writer.Write(MinDate);
            writer.Write(MaxDate);
        }

        public override void Deserialize(Reader reader)
        {
            MinDate = reader.Read<int>();
            MaxDate = reader.Read<int>();
        }
    }
}