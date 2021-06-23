using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public class InputPrivacyValueDisallowContacts : InputPrivacyRuleBase
    {
        public static int ConstructorId { get; } = 195371015;

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