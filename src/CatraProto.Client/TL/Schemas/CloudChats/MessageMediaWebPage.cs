using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public class MessageMediaWebPage : MessageMediaBase
    {
        public static int ConstructorId { get; } = -1557277184;
        public WebPageBase Webpage { get; set; }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            writer.Write(Webpage);
        }

        public override void Deserialize(Reader reader)
        {
            Webpage = reader.Read<WebPageBase>();
        }
    }
}