using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class UpdatesTooLong : CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -484987010; }



        public UpdatesTooLong()
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
            return "updatesTooLong";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }
    }
}