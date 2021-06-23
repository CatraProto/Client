using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public class PhoneConnection : PhoneConnectionBase
    {
        public static int ConstructorId { get; } = -1655957568;
        public override long Id { get; set; }
        public override string Ip { get; set; }
        public override string Ipv6 { get; set; }
        public override int Port { get; set; }
        public byte[] PeerTag { get; set; }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            writer.Write(Id);
            writer.Write(Ip);
            writer.Write(Ipv6);
            writer.Write(Port);
            writer.Write(PeerTag);
        }

        public override void Deserialize(Reader reader)
        {
            Id = reader.Read<long>();
            Ip = reader.Read<string>();
            Ipv6 = reader.Read<string>();
            Port = reader.Read<int>();
            PeerTag = reader.Read<byte[]>();
        }
    }
}