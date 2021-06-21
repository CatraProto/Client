using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class GetRecentLocations : IMethod
    {
        public static int ConstructorId { get; } = -1144759543;
        public InputPeerBase Peer { get; set; }
        public int Limit { get; set; }
        public int Hash { get; set; }

        public Type Type { get; init; } = typeof(MessagesBase);
        public bool IsVector { get; init; } = false;

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            writer.Write(Peer);
            writer.Write(Limit);
            writer.Write(Hash);
        }

        public void Deserialize(Reader reader)
        {
            Peer = reader.Read<InputPeerBase>();
            Limit = reader.Read<int>();
            Hash = reader.Read<int>();
        }
    }
}