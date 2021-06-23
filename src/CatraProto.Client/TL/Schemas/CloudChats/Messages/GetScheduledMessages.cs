using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public class GetScheduledMessages : IMethod
    {
        public static int ConstructorId { get; } = -1111817116;

        public System.Type Type { get; init; } = typeof(MessagesBase);
        public bool IsVector { get; init; } = false;
        public InputPeerBase Peer { get; set; }
        public IList<int> Id { get; set; }

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
            writer.Write(Id);
        }

        public void Deserialize(Reader reader)
        {
            Peer = reader.Read<InputPeerBase>();
            Id = reader.ReadVector<int>();
        }
    }
}