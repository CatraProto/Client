using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class MessageInteractionCounters : MessageInteractionCountersBase
    {
        public static int ConstructorId { get; } = -1387279939;
        public override int MsgId { get; set; }
        public override int Views { get; set; }
        public override int Forwards { get; set; }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            writer.Write(MsgId);
            writer.Write(Views);
            writer.Write(Forwards);
        }

        public override void Deserialize(Reader reader)
        {
            MsgId = reader.Read<int>();
            Views = reader.Read<int>();
            Forwards = reader.Read<int>();
        }
    }
}