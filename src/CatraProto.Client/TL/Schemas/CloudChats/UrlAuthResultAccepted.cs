using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public class UrlAuthResultAccepted : UrlAuthResultBase
    {
        public static int ConstructorId { get; } = -1886646706;
        public string Url { get; set; }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            writer.Write(Url);
        }

        public override void Deserialize(Reader reader)
        {
            Url = reader.Read<string>();
        }
    }
}