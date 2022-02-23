using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class InputPrivacyValueAllowAll : CatraProto.Client.TL.Schemas.CloudChats.InputPrivacyRuleBase
    {
        public static int StaticConstructorId
        {
            get => 407582158;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }


        public InputPrivacyValueAllowAll()
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
            return "inputPrivacyValueAllowAll";
        }
    }
}