using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class DocumentAttributeAnimated : CatraProto.Client.TL.Schemas.CloudChats.DocumentAttributeBase
    {
        public static int StaticConstructorId
        {
            get => 297109817;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }


        public DocumentAttributeAnimated()
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
            return "documentAttributeAnimated";
        }
    }
}