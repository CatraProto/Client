using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class UrlAuthResultDefault : CatraProto.Client.TL.Schemas.CloudChats.UrlAuthResultBase
    {
        public static int StaticConstructorId
        {
            get => -1445536993;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }


        public UrlAuthResultDefault()
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
            return "urlAuthResultDefault";
        }
    }
}