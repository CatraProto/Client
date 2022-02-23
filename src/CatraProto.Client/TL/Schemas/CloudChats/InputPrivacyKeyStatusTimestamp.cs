using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class InputPrivacyKeyStatusTimestamp : CatraProto.Client.TL.Schemas.CloudChats.InputPrivacyKeyBase
    {
        public static int StaticConstructorId
        {
            get => 1335282456;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }


        public InputPrivacyKeyStatusTimestamp()
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
            return "inputPrivacyKeyStatusTimestamp";
        }
    }
}