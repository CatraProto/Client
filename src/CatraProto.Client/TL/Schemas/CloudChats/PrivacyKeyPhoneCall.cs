using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class PrivacyKeyPhoneCall : CatraProto.Client.TL.Schemas.CloudChats.PrivacyKeyBase
    {
        public static int StaticConstructorId
        {
            get => 1030105979;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }


        public PrivacyKeyPhoneCall()
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
            return "privacyKeyPhoneCall";
        }
    }
}