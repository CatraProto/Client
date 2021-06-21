using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class GetReplies : IMethod
    {
        public static int ConstructorId { get; } = 615875002;
        public InputPeerBase Peer { get; set; }
        public int MsgId { get; set; }
        public int OffsetId { get; set; }
        public int OffsetDate { get; set; }
        public int AddOffset { get; set; }
        public int Limit { get; set; }
        public int MaxId { get; set; }
        public int MinId { get; set; }
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
            writer.Write(MsgId);
            writer.Write(OffsetId);
            writer.Write(OffsetDate);
            writer.Write(AddOffset);
            writer.Write(Limit);
            writer.Write(MaxId);
            writer.Write(MinId);
            writer.Write(Hash);
        }

        public void Deserialize(Reader reader)
        {
            Peer = reader.Read<InputPeerBase>();
            MsgId = reader.Read<int>();
            OffsetId = reader.Read<int>();
            OffsetDate = reader.Read<int>();
            AddOffset = reader.Read<int>();
            Limit = reader.Read<int>();
            MaxId = reader.Read<int>();
            MinId = reader.Read<int>();
            Hash = reader.Read<int>();
        }
    }
}