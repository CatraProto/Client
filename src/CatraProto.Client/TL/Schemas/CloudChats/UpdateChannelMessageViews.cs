using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public class UpdateChannelMessageViews : UpdateBase
    {
        public static int ConstructorId { get; } = -1734268085;
        public int ChannelId { get; set; }
        public int Id { get; set; }
        public int Views { get; set; }

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
            writer.Write(Id);
            writer.Write(Views);
        }

        public override void Deserialize(Reader reader)
        {
            ChannelId = reader.Read<int>();
            Id = reader.Read<int>();
            Views = reader.Read<int>();
        }
    }
}