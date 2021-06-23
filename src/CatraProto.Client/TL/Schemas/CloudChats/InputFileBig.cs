using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public class InputFileBig : InputFileBase
    {
        public static int ConstructorId { get; } = -95482955;
        public override long Id { get; set; }
        public override int Parts { get; set; }
        public override string Name { get; set; }

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
            writer.Write(Parts);
            writer.Write(Name);
        }

        public override void Deserialize(Reader reader)
        {
            Id = reader.Read<long>();
            Parts = reader.Read<int>();
            Name = reader.Read<string>();
        }
    }
}