using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public partial class WallPapersNotModified : CatraProto.Client.TL.Schemas.CloudChats.Account.WallPapersBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 471437699; }



        public WallPapersNotModified()
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
            return "account.wallPapersNotModified";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }
    }
}