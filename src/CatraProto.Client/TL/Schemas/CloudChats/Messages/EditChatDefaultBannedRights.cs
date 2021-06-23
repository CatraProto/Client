using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public class EditChatDefaultBannedRights : IMethod
    {
        public static int ConstructorId { get; } = -1517917375;

        public System.Type Type { get; init; } = typeof(UpdatesBase);
        public bool IsVector { get; init; } = false;
        public InputPeerBase Peer { get; set; }
        public ChatBannedRightsBase BannedRights { get; set; }

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
            writer.Write(BannedRights);
        }

        public void Deserialize(Reader reader)
        {
            Peer = reader.Read<InputPeerBase>();
            BannedRights = reader.Read<ChatBannedRightsBase>();
        }
    }
}