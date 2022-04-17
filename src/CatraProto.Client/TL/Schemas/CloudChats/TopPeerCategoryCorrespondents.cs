using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class TopPeerCategoryCorrespondents : CatraProto.Client.TL.Schemas.CloudChats.TopPeerCategoryBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 104314861; }



        public TopPeerCategoryCorrespondents()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "topPeerCategoryCorrespondents";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }
    }
}