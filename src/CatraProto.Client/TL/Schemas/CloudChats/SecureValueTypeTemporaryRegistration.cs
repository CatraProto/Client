using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class SecureValueTypeTemporaryRegistration : CatraProto.Client.TL.Schemas.CloudChats.SecureValueTypeBase
    {
        public static int StaticConstructorId
        {
            get => -368907213;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }


        public SecureValueTypeTemporaryRegistration()
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
            return "secureValueTypeTemporaryRegistration";
        }
    }
}