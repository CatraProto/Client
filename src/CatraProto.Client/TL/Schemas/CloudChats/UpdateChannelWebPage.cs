using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public class UpdateChannelWebPage : UpdateBase
    {
        public static int ConstructorId { get; } = 1081547008;
        public int ChannelId { get; set; }
        public WebPageBase Webpage { get; set; }
        public int Pts { get; set; }
        public int PtsCount { get; set; }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            writer.Write(ChannelId);
            writer.Write(Webpage);
            writer.Write(Pts);
            writer.Write(PtsCount);
        }

        public override void Deserialize(Reader reader)
        {
            ChannelId = reader.Read<int>();
            Webpage = reader.Read<WebPageBase>();
            Pts = reader.Read<int>();
            PtsCount = reader.Read<int>();
        }
    }
}