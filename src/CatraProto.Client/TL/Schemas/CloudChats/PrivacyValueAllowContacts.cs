using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class PrivacyValueAllowContacts : CatraProto.Client.TL.Schemas.CloudChats.PrivacyRuleBase
    {
        public static int StaticConstructorId
        {
            get => -123988;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }


        public PrivacyValueAllowContacts()
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
            return "privacyValueAllowContacts";
        }
    }
}