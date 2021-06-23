using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public class StatsAbsValueAndPrev : StatsAbsValueAndPrevBase
    {
        public static int ConstructorId { get; } = -884757282;
        public override double Current { get; set; }
        public override double Previous { get; set; }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            writer.Write(Current);
            writer.Write(Previous);
        }

        public override void Deserialize(Reader reader)
        {
            Current = reader.Read<double>();
            Previous = reader.Read<double>();
        }
    }
}