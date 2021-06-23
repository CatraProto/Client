using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public class UploadEncryptedFile : IMethod
    {
        public static int ConstructorId { get; } = 1347929239;

        public System.Type Type { get; init; } = typeof(EncryptedFileBase);
        public bool IsVector { get; init; } = false;
        public InputEncryptedChatBase Peer { get; set; }
        public InputEncryptedFileBase File { get; set; }

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            writer.Write(Peer);
            writer.Write(File);
        }

        public void Deserialize(Reader reader)
        {
            Peer = reader.Read<InputEncryptedChatBase>();
            File = reader.Read<InputEncryptedFileBase>();
        }
    }
}