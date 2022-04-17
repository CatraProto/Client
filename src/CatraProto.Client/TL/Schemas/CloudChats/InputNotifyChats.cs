using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class InputNotifyChats : CatraProto.Client.TL.Schemas.CloudChats.InputNotifyPeerBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1251338318; }



        public InputNotifyChats()
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
            return "inputNotifyChats";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }
    }
}