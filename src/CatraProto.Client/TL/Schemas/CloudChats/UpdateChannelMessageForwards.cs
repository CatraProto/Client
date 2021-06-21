using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class UpdateChannelMessageForwards : UpdateBase
    {
        public static int ConstructorId { get; } = 1854571743;
        public int ChannelId { get; set; }
        public int Id { get; set; }
        public int Forwards { get; set; }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            writer.Write(ChannelId);
            writer.Write(Id);
            writer.Write(Forwards);
        }

        public override void Deserialize(Reader reader)
        {
            ChannelId = reader.Read<int>();
            Id = reader.Read<int>();
            Forwards = reader.Read<int>();
        }
    }
}