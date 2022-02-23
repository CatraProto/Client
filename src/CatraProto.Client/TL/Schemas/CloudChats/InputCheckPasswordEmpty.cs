using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class InputCheckPasswordEmpty : CatraProto.Client.TL.Schemas.CloudChats.InputCheckPasswordSRPBase
    {
        public static int StaticConstructorId
        {
            get => -1736378792;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }


        public InputCheckPasswordEmpty()
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
            return "inputCheckPasswordEmpty";
        }
    }
}