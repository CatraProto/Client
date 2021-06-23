using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public class SendMessageChooseContactAction : SendMessageActionBase
    {
        public static int ConstructorId { get; } = 1653390447;

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