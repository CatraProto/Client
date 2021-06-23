using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.MTProto
{
    public class RpcAnswerDropped : RpcDropAnswerBase
    {
        public static int ConstructorId { get; } = -1539647305;
        public long MsgId { get; set; }
        public int SeqNo { get; set; }
        public int Bytes { get; set; }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            writer.Write(MsgId);
            writer.Write(SeqNo);
            writer.Write(Bytes);
        }

        public override void Deserialize(Reader reader)
        {
            MsgId = reader.Read<long>();
            SeqNo = reader.Read<int>();
            Bytes = reader.Read<int>();
        }
    }
}