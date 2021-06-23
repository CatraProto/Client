using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public class InputCheckPasswordSRP : InputCheckPasswordSRPBase
    {
        public static int ConstructorId { get; } = -763367294;
        public long SrpId { get; set; }
        public byte[] A { get; set; }
        public byte[] M1 { get; set; }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            writer.Write(SrpId);
            writer.Write(A);
            writer.Write(M1);
        }

        public override void Deserialize(Reader reader)
        {
            SrpId = reader.Read<long>();
            A = reader.Read<byte[]>();
            M1 = reader.Read<byte[]>();
        }
    }
}