using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.MTProto
{
    public partial class RpcAnswerDroppedRunning : CatraProto.Client.TL.Schemas.MTProto.RpcDropAnswerBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -847714938; }



        public RpcAnswerDroppedRunning()
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
            return "rpc_answer_dropped_running";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }
    }
}