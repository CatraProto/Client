using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Help
{
    public partial class NoAppUpdate : CatraProto.Client.TL.Schemas.CloudChats.Help.AppUpdateBase
    {
        public static int StaticConstructorId
        {
            get => -1000708810;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }


        public NoAppUpdate()
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
            return "help.noAppUpdate";
        }
    }
}