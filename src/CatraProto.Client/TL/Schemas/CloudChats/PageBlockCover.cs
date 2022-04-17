using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class PageBlockCover : CatraProto.Client.TL.Schemas.CloudChats.PageBlockBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 972174080; }

        [Newtonsoft.Json.JsonProperty("cover")]
        public CatraProto.Client.TL.Schemas.CloudChats.PageBlockBase Cover { get; set; }


#nullable enable
        public PageBlockCover(CatraProto.Client.TL.Schemas.CloudChats.PageBlockBase cover)
        {
            Cover = cover;

        }
#nullable disable
        internal PageBlockCover()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkcover = writer.WriteObject(Cover);
            if (checkcover.IsError)
            {
                return checkcover;
            }

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trycover = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.PageBlockBase>();
            if (trycover.IsError)
            {
                return ReadResult<IObject>.Move(trycover);
            }
            Cover = trycover.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "pageBlockCover";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }
    }
}