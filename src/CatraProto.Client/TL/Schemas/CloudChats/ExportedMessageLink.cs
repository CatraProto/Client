using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public class ExportedMessageLink : ExportedMessageLinkBase
    {
        public static int ConstructorId { get; } = 1571494644;
        public override string Link { get; set; }
        public override string Html { get; set; }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            writer.Write(Link);
            writer.Write(Html);
        }

        public override void Deserialize(Reader reader)
        {
            Link = reader.Read<string>();
            Html = reader.Read<string>();
        }
    }
}