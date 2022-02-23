using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class InputPrivacyValueAllowContacts : CatraProto.Client.TL.Schemas.CloudChats.InputPrivacyRuleBase
    {
        public static int StaticConstructorId
        {
            get => 218751099;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }


        public InputPrivacyValueAllowContacts()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
        }

        public override void Deserialize(Reader reader)
        {
        }

        public override string ToString()
        {
            return "inputPrivacyValueAllowContacts";
        }
    }
}