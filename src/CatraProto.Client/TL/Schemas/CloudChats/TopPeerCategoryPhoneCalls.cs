using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class TopPeerCategoryPhoneCalls : CatraProto.Client.TL.Schemas.CloudChats.TopPeerCategoryBase
    {
        public static int StaticConstructorId
        {
            get => 511092620;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }


        public TopPeerCategoryPhoneCalls()
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
            return "topPeerCategoryPhoneCalls";
        }
    }
}