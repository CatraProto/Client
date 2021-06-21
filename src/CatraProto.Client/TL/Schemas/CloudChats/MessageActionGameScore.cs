using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class MessageActionGameScore : MessageActionBase
    {
        public static int ConstructorId { get; } = -1834538890;
        public long GameId { get; set; }
        public int Score { get; set; }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            writer.Write(GameId);
            writer.Write(Score);
        }

        public override void Deserialize(Reader reader)
        {
            GameId = reader.Read<long>();
            Score = reader.Read<int>();
        }
    }
}