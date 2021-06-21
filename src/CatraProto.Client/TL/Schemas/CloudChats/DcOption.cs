using System;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class DcOption : DcOptionBase
    {
        public static int ConstructorId { get; } = 414687501;
        public int Flags { get; set; }
        public override bool Ipv6 { get; set; }
        public override bool MediaOnly { get; set; }
        public override bool TcpoOnly { get; set; }
        public override bool Cdn { get; set; }
        public override bool Static { get; set; }
        public override int Id { get; set; }
        public override string IpAddress { get; set; }
        public override int Port { get; set; }
        public override byte[] Secret { get; set; }

        [Flags]
        public enum FlagsEnum
        {
            Ipv6 = 1 << 0,
            MediaOnly = 1 << 1,
            TcpoOnly = 1 << 2,
            Cdn = 1 << 3,
            Static = 1 << 4,
            Secret = 1 << 10
        }

        public override void UpdateFlags()
        {
            Flags = Ipv6 ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
            Flags = MediaOnly ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
            Flags = TcpoOnly ? FlagsHelper.SetFlag(Flags, 2) : FlagsHelper.UnsetFlag(Flags, 2);
            Flags = Cdn ? FlagsHelper.SetFlag(Flags, 3) : FlagsHelper.UnsetFlag(Flags, 3);
            Flags = Static ? FlagsHelper.SetFlag(Flags, 4) : FlagsHelper.UnsetFlag(Flags, 4);
            Flags = Secret == null ? FlagsHelper.UnsetFlag(Flags, 10) : FlagsHelper.SetFlag(Flags, 10);
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            UpdateFlags();
            writer.Write(Flags);
            writer.Write(Id);
            writer.Write(IpAddress);
            writer.Write(Port);
            if (FlagsHelper.IsFlagSet(Flags, 10))
            {
                writer.Write(Secret);
            }
        }

        public override void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            Ipv6 = FlagsHelper.IsFlagSet(Flags, 0);
            MediaOnly = FlagsHelper.IsFlagSet(Flags, 1);
            TcpoOnly = FlagsHelper.IsFlagSet(Flags, 2);
            Cdn = FlagsHelper.IsFlagSet(Flags, 3);
            Static = FlagsHelper.IsFlagSet(Flags, 4);
            Id = reader.Read<int>();
            IpAddress = reader.Read<string>();
            Port = reader.Read<int>();
            if (FlagsHelper.IsFlagSet(Flags, 10))
            {
                Secret = reader.Read<byte[]>();
            }
        }
    }
}