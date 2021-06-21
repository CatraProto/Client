using System.Collections.Generic;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.MTProto
{
    public partial class FutureSalts : FutureSaltsBase
    {
        public static int ConstructorId { get; } = -1370486635;
        public override long ReqMsgId { get; set; }
        public override int Now { get; set; }
        public override IList<FutureSaltBase> Salts { get; set; }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            writer.Write(ReqMsgId);
            writer.Write(Now);
            writer.Write(Salts);
        }

        public override void Deserialize(Reader reader)
        {
            ReqMsgId = reader.Read<long>();
            Now = reader.Read<int>();
            Salts = reader.ReadVector<FutureSaltBase>();
        }
    }
}