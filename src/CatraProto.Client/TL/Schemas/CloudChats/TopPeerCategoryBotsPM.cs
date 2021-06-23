using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public class TopPeerCategoryBotsPM : TopPeerCategoryBase
    {
        public static int ConstructorId { get; } = -1419371685;

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }
        }

        public override void Deserialize(Reader reader)
        {
        }
    }
}