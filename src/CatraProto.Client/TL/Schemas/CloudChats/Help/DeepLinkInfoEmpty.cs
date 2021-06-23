using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats.Help
{
    public class DeepLinkInfoEmpty : DeepLinkInfoBase
    {
        public static int ConstructorId { get; } = 1722786150;

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