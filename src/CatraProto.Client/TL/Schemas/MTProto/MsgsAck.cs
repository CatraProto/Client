using System.Collections.Generic;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.MTProto
{
    public partial class MsgsAck : MsgsAckBase
    {
        public static int ConstructorId { get; } = 1658238041;
        public override IList<long> MsgIds { get; set; }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            writer.Write(MsgIds);
        }

        public override void Deserialize(Reader reader)
        {
            MsgIds = reader.ReadVector<long>();
        }
    }
}