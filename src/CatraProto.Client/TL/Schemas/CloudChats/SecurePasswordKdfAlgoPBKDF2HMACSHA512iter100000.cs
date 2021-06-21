using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class SecurePasswordKdfAlgoPBKDF2HMACSHA512iter100000 : SecurePasswordKdfAlgoBase
    {
        public static int ConstructorId { get; } = -1141711456;
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