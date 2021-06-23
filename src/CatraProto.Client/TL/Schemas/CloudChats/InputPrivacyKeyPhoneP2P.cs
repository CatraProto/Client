using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public class InputPrivacyKeyPhoneP2P : InputPrivacyKeyBase
    {
        public static int ConstructorId { get; } = -610373422;

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