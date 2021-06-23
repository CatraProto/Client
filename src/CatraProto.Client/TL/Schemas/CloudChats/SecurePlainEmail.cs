using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public class SecurePlainEmail : SecurePlainDataBase
    {
        public static int ConstructorId { get; } = 569137759;
        public string Email { get; set; }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            writer.Write(Email);
        }

        public override void Deserialize(Reader reader)
        {
            Email = reader.Read<string>();
        }
    }
}