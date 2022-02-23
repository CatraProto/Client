using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class DocumentAttributeHasStickers : CatraProto.Client.TL.Schemas.CloudChats.DocumentAttributeBase
    {
        public static int StaticConstructorId
        {
            get => -1744710921;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }


        public DocumentAttributeHasStickers()
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
            return "documentAttributeHasStickers";
        }
    }
}