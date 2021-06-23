using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public class SecureValueHash : SecureValueHashBase
    {
        public static int ConstructorId { get; } = -316748368;
        public override SecureValueTypeBase Type { get; set; }
        public override byte[] Hash { get; set; }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            writer.Write(Type);
            writer.Write(Hash);
        }

        public override void Deserialize(Reader reader)
        {
            Type = reader.Read<SecureValueTypeBase>();
            Hash = reader.Read<byte[]>();
        }
    }
}