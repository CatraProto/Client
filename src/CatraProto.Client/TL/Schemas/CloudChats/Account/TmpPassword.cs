using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public class TmpPassword : TmpPasswordBase
    {
        public static int ConstructorId { get; } = -614138572;
        public override byte[] TmpPassword_ { get; set; }
        public override int ValidUntil { get; set; }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            writer.Write(TmpPassword_);
            writer.Write(ValidUntil);
        }

        public override void Deserialize(Reader reader)
        {
            TmpPassword_ = reader.Read<byte[]>();
            ValidUntil = reader.Read<int>();
        }
    }
}