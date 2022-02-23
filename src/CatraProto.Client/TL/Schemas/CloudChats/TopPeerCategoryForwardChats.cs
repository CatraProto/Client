using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class TopPeerCategoryForwardChats : CatraProto.Client.TL.Schemas.CloudChats.TopPeerCategoryBase
    {
        public static int StaticConstructorId
        {
            get => -68239120;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }


        public TopPeerCategoryForwardChats()
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
            return "topPeerCategoryForwardChats";
        }
    }
}