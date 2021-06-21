using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class SendEncryptedService : IMethod
    {
        public static int ConstructorId { get; } = 852769188;
        public InputEncryptedChatBase Peer { get; set; }
        public long RandomId { get; set; }
        public byte[] Data { get; set; }

        public Type Type { get; init; } = typeof(SentEncryptedMessageBase);
        public bool IsVector { get; init; } = false;

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            writer.Write(Peer);
            writer.Write(RandomId);
            writer.Write(Data);
        }

        public void Deserialize(Reader reader)
        {
            Peer = reader.Read<InputEncryptedChatBase>();
            RandomId = reader.Read<long>();
            Data = reader.Read<byte[]>();
        }
    }
}