using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats.Auth
{
    public partial class LoginToken : LoginTokenBase
    {
        public static int ConstructorId { get; } = 1654593920;
        public int Expires { get; set; }
        public byte[] Token { get; set; }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            writer.Write(Expires);
            writer.Write(Token);
        }

        public override void Deserialize(Reader reader)
        {
            Expires = reader.Read<int>();
            Token = reader.Read<byte[]>();
        }
    }
}