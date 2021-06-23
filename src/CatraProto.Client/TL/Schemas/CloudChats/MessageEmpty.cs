using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public class MessageEmpty : MessageBase
    {
        public static int ConstructorId { get; } = -2082087340;
        public override int Id { get; set; }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            writer.Write(Id);
        }

        public override void Deserialize(Reader reader)
        {
            Id = reader.Read<int>();
        }
    }
}