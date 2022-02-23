using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class InputTakeoutFileLocation : CatraProto.Client.TL.Schemas.CloudChats.InputFileLocationBase
    {
        public static int StaticConstructorId
        {
            get => 700340377;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }


        public InputTakeoutFileLocation()
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
            return "inputTakeoutFileLocation";
        }
    }
}