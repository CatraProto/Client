using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Auth
{
    public partial class CodeTypeMissedCall : CatraProto.Client.TL.Schemas.CloudChats.Auth.CodeTypeBase
    {
        public static int StaticConstructorId
        {
            get => -702884114;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }


        public CodeTypeMissedCall()
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
            return "auth.codeTypeMissedCall";
        }
    }
}