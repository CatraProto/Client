using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class InputCheckPasswordEmpty : CatraProto.Client.TL.Schemas.CloudChats.InputCheckPasswordSRPBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1736378792; }



        public InputCheckPasswordEmpty()
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
            return "inputCheckPasswordEmpty";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }
    }
}