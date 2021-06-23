using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public class MessageEntityPre : MessageEntityBase
    {
        public static int ConstructorId { get; } = 1938967520;
        public override int Offset { get; set; }
        public override int Length { get; set; }
        public string Language { get; set; }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            writer.Write(Offset);
            writer.Write(Length);
            writer.Write(Language);
        }

        public override void Deserialize(Reader reader)
        {
            Offset = reader.Read<int>();
            Length = reader.Read<int>();
            Language = reader.Read<string>();
        }
    }
}