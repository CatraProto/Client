using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats.Auth
{
    public class ExportedAuthorization : ExportedAuthorizationBase
    {
        public static int ConstructorId { get; } = -543777747;
        public override int Id { get; set; }
        public override byte[] Bytes { get; set; }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            writer.Write(Id);
            writer.Write(Bytes);
        }

        public override void Deserialize(Reader reader)
        {
            Id = reader.Read<int>();
            Bytes = reader.Read<byte[]>();
        }
    }
}