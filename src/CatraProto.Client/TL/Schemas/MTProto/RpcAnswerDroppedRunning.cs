using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.MTProto
{
    public partial class RpcAnswerDroppedRunning : CatraProto.Client.TL.Schemas.MTProto.RpcDropAnswerBase
    {
        public static int StaticConstructorId
        {
            get => -847714938;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }


        public RpcAnswerDroppedRunning()
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
            return "rpc_answer_dropped_running";
        }
    }
}