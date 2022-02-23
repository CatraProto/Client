using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class InputPrivacyKeyForwards : CatraProto.Client.TL.Schemas.CloudChats.InputPrivacyKeyBase
    {
        public static int StaticConstructorId
        {
            get => -1529000952;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }


        public InputPrivacyKeyForwards()
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
            return "inputPrivacyKeyForwards";
        }
    }
}