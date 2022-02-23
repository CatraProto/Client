using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class PasswordKdfAlgoUnknown : CatraProto.Client.TL.Schemas.CloudChats.PasswordKdfAlgoBase
    {
        public static int StaticConstructorId
        {
            get => -732254058;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }


        public PasswordKdfAlgoUnknown()
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
            return "passwordKdfAlgoUnknown";
        }
    }
}