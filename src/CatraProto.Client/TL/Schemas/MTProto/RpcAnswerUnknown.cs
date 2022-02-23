using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.MTProto
{
    public partial class RpcAnswerUnknown : CatraProto.Client.TL.Schemas.MTProto.RpcDropAnswerBase
    {
        public static int StaticConstructorId
        {
            get => 1579864942;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }


        public RpcAnswerUnknown()
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
            return "rpc_answer_unknown";
        }
    }
}