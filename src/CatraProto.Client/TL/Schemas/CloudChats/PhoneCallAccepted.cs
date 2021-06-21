using System;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class PhoneCallAccepted : PhoneCallBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Video = 1 << 6
        }

        public static int ConstructorId { get; } = -1719909046;
        public int Flags { get; set; }
        public bool Video { get; set; }
        public override long Id { get; set; }
        public long AccessHash { get; set; }
        public int Date { get; set; }
        public int AdminId { get; set; }
        public int ParticipantId { get; set; }
        public byte[] GB { get; set; }
        public PhoneCallProtocolBase Protocol { get; set; }

        public override void UpdateFlags()
        {
            Flags = Video ? FlagsHelper.SetFlag(Flags, 6) : FlagsHelper.UnsetFlag(Flags, 6);
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            UpdateFlags();
            writer.Write(Flags);
            writer.Write(Id);
            writer.Write(AccessHash);
            writer.Write(Date);
            writer.Write(AdminId);
            writer.Write(ParticipantId);
            writer.Write(GB);
            writer.Write(Protocol);
        }

        public override void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            Video = FlagsHelper.IsFlagSet(Flags, 6);
            Id = reader.Read<long>();
            AccessHash = reader.Read<long>();
            Date = reader.Read<int>();
            AdminId = reader.Read<int>();
            ParticipantId = reader.Read<int>();
            GB = reader.Read<byte[]>();
            Protocol = reader.Read<PhoneCallProtocolBase>();
        }
    }
}