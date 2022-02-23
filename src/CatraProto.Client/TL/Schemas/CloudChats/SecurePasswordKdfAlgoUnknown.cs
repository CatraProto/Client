using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class SecurePasswordKdfAlgoUnknown : CatraProto.Client.TL.Schemas.CloudChats.SecurePasswordKdfAlgoBase
    {
        public static int StaticConstructorId
        {
            get => 4883767;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }


        public SecurePasswordKdfAlgoUnknown()
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
            return "securePasswordKdfAlgoUnknown";
        }
    }
}