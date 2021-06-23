using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public class PhoneCallDiscardReasonBusy : PhoneCallDiscardReasonBase
    {
        public static int ConstructorId { get; } = -84416311;

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