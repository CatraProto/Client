using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public class ImportedContact : ImportedContactBase
    {
        public static int ConstructorId { get; } = -805141448;
        public override int UserId { get; set; }
        public override long ClientId { get; set; }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            writer.Write(UserId);
            writer.Write(ClientId);
        }

        public override void Deserialize(Reader reader)
        {
            UserId = reader.Read<int>();
            ClientId = reader.Read<long>();
        }
    }
}