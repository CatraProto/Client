using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public class InputBotInlineMessageID : InputBotInlineMessageIDBase
    {
        public static int ConstructorId { get; } = -1995686519;
        public override int DcId { get; set; }
        public override long Id { get; set; }
        public override long AccessHash { get; set; }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            writer.Write(DcId);
            writer.Write(Id);
            writer.Write(AccessHash);
        }

        public override void Deserialize(Reader reader)
        {
            DcId = reader.Read<int>();
            Id = reader.Read<long>();
            AccessHash = reader.Read<long>();
        }
    }
}