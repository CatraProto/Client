using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class UpdateNewEncryptedMessage : UpdateBase
    {
        public static int ConstructorId { get; } = 314359194;
        public EncryptedMessageBase Message { get; set; }
        public int Qts { get; set; }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            writer.Write(Message);
            writer.Write(Qts);
        }

        public override void Deserialize(Reader reader)
        {
            Message = reader.Read<EncryptedMessageBase>();
            Qts = reader.Read<int>();
        }
    }
}