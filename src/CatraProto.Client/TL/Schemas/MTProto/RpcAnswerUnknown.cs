using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.MTProto
{
    public class RpcAnswerUnknown : RpcDropAnswerBase
    {
        public static int ConstructorId { get; } = 1579864942;

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