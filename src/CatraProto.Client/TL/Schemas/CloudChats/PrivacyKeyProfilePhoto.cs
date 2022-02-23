using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class PrivacyKeyProfilePhoto : CatraProto.Client.TL.Schemas.CloudChats.PrivacyKeyBase
    {
        public static int StaticConstructorId
        {
            get => -1777000467;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }


        public PrivacyKeyProfilePhoto()
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
            return "privacyKeyProfilePhoto";
        }
    }
}