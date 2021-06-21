using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Phone
{
    public partial class AcceptCall : IMethod
    {
        public static int ConstructorId { get; } = 1003664544;
        public InputPhoneCallBase Peer { get; set; }
        public byte[] GB { get; set; }
        public PhoneCallProtocolBase Protocol { get; set; }

        public Type Type { get; init; } = typeof(PhoneCallBase);
        public bool IsVector { get; init; } = false;

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            writer.Write(Peer);
            writer.Write(GB);
            writer.Write(Protocol);
        }

        public void Deserialize(Reader reader)
        {
            Peer = reader.Read<InputPhoneCallBase>();
            GB = reader.Read<byte[]>();
            Protocol = reader.Read<PhoneCallProtocolBase>();
        }
    }
}