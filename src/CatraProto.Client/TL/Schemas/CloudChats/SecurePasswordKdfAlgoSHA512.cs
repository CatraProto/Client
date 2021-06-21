using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class SecurePasswordKdfAlgoSHA512 : SecurePasswordKdfAlgoBase
    {
        public static int ConstructorId { get; } = -2042159726;
        public byte[] Salt { get; set; }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            writer.Write(Salt);
        }

        public override void Deserialize(Reader reader)
        {
            Salt = reader.Read<byte[]>();
        }
    }
}