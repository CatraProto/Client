using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public class SendMessageRecordVideoAction : SendMessageActionBase
    {
        public static int ConstructorId { get; } = -1584933265;

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