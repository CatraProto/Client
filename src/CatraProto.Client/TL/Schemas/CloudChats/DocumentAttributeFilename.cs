using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public class DocumentAttributeFilename : DocumentAttributeBase
    {
        public static int ConstructorId { get; } = 358154344;
        public string FileName { get; set; }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            writer.Write(FileName);
        }

        public override void Deserialize(Reader reader)
        {
            FileName = reader.Read<string>();
        }
    }
}