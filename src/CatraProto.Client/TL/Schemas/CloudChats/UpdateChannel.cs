using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public class UpdateChannel : UpdateBase
    {
        public static int ConstructorId { get; } = -1227598250;
        public int ChannelId { get; set; }

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
        }

        public override void Deserialize(Reader reader)
        {
            ChannelId = reader.Read<int>();
        }
    }
}