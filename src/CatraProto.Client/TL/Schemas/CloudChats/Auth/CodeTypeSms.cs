using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Auth
{
    public partial class CodeTypeSms : CatraProto.Client.TL.Schemas.CloudChats.Auth.CodeTypeBase
    {
        public static int StaticConstructorId
        {
            get => 1923290508;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }


        public CodeTypeSms()
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
            return "auth.codeTypeSms";
        }
    }
}