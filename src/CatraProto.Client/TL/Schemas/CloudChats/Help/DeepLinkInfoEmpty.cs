using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Help
{
    public partial class DeepLinkInfoEmpty : CatraProto.Client.TL.Schemas.CloudChats.Help.DeepLinkInfoBase
    {
        public static int StaticConstructorId
        {
            get => 1722786150;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }


        public DeepLinkInfoEmpty()
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
            return "help.deepLinkInfoEmpty";
        }
    }
}