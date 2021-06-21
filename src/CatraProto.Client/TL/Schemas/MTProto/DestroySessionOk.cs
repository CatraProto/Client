using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.MTProto
{
    public partial class DestroySessionOk : DestroySessionResBase
    {
        public static int ConstructorId { get; } = -501201412;
        public override long SessionId { get; set; }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            writer.Write(SessionId);
        }

        public override void Deserialize(Reader reader)
        {
            SessionId = reader.Read<long>();
        }
    }
}