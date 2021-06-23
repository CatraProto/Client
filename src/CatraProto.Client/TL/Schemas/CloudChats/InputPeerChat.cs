using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public class InputPeerChat : InputPeerBase
    {
        public static int ConstructorId { get; } = 396093539;
        public int ChatId { get; set; }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            writer.Write(ChatId);
        }

        public override void Deserialize(Reader reader)
        {
            ChatId = reader.Read<int>();
        }
    }
}