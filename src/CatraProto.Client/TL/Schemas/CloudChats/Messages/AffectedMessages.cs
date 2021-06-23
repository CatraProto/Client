using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public class AffectedMessages : AffectedMessagesBase
    {
        public static int ConstructorId { get; } = -2066640507;
        public override int Pts { get; set; }
        public override int PtsCount { get; set; }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            writer.Write(Pts);
            writer.Write(PtsCount);
        }

        public override void Deserialize(Reader reader)
        {
            Pts = reader.Read<int>();
            PtsCount = reader.Read<int>();
        }
    }
}