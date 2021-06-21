using System.Collections.Generic;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.MTProto
{
    public partial class MsgsAllInfo : MsgsAllInfoBase
    {
        public static int ConstructorId { get; } = -1933520591;
        public override IList<long> MsgIds { get; set; }
        public override byte[] Info { get; set; }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            writer.Write(MsgIds);
            writer.Write(Info);
        }

        public override void Deserialize(Reader reader)
        {
            MsgIds = reader.ReadVector<long>();
            Info = reader.Read<byte[]>();
        }
    }
}