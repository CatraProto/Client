using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public class MessageMediaGame : MessageMediaBase
    {
        public static int ConstructorId { get; } = -38694904;
        public GameBase Game { get; set; }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            writer.Write(Game);
        }

        public override void Deserialize(Reader reader)
        {
            Game = reader.Read<GameBase>();
        }
    }
}