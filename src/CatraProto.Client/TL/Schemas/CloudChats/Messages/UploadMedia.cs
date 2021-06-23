using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public class UploadMedia : IMethod
    {
        public static int ConstructorId { get; } = 1369162417;

        public System.Type Type { get; init; } = typeof(MessageMediaBase);
        public bool IsVector { get; init; } = false;
        public InputPeerBase Peer { get; set; }
        public InputMediaBase Media { get; set; }

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
            writer.Write(Media);
        }

        public void Deserialize(Reader reader)
        {
            Peer = reader.Read<InputPeerBase>();
            Media = reader.Read<InputMediaBase>();
        }
    }
}