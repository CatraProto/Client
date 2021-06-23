using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.MTProto
{
    public class RpcAnswerDroppedRunning : RpcDropAnswerBase
    {
        public static int ConstructorId { get; } = -847714938;

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