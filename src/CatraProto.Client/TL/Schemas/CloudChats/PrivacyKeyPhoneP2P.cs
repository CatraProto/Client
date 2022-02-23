using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class PrivacyKeyPhoneP2P : CatraProto.Client.TL.Schemas.CloudChats.PrivacyKeyBase
    {
        public static int StaticConstructorId
        {
            get => 961092808;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }


        public PrivacyKeyPhoneP2P()
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
            return "privacyKeyPhoneP2P";
        }
    }
}