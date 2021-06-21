using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.MTProto
{
    public partial class FutureSalt : FutureSaltBase
    {
        public static int ConstructorId { get; } = 155834844;
        public override int ValidSince { get; set; }
        public override int ValidUntil { get; set; }
        public override long Salt { get; set; }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            writer.Write(ValidSince);
            writer.Write(ValidUntil);
            writer.Write(Salt);
        }

        public override void Deserialize(Reader reader)
        {
            ValidSince = reader.Read<int>();
            ValidUntil = reader.Read<int>();
            Salt = reader.Read<long>();
        }
    }
}