using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats.Auth
{
    public class LoginTokenMigrateTo : LoginTokenBase
    {
        public static int ConstructorId { get; } = 110008598;
        public int DcId { get; set; }
        public byte[] Token { get; set; }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            writer.Write(DcId);
            writer.Write(Token);
        }

        public override void Deserialize(Reader reader)
        {
            DcId = reader.Read<int>();
            Token = reader.Read<byte[]>();
        }
    }
}