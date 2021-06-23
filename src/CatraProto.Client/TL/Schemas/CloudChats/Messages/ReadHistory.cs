using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public class ReadHistory : IMethod
    {
        public static int ConstructorId { get; } = 238054714;

        public System.Type Type { get; init; } = typeof(AffectedMessagesBase);
        public bool IsVector { get; init; } = false;
        public InputPeerBase Peer { get; set; }
        public int MaxId { get; set; }

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
            writer.Write(MaxId);
        }

        public void Deserialize(Reader reader)
        {
            Peer = reader.Read<InputPeerBase>();
            MaxId = reader.Read<int>();
        }
    }
}