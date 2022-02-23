using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Help
{
    public partial class PassportConfigNotModified : CatraProto.Client.TL.Schemas.CloudChats.Help.PassportConfigBase
    {
        public static int StaticConstructorId
        {
            get => -1078332329;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }


        public PassportConfigNotModified()
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
            return "help.passportConfigNotModified";
        }
    }
}