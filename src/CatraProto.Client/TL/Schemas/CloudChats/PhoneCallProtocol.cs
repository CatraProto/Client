using System;
using System.Collections.Generic;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public class PhoneCallProtocol : PhoneCallProtocolBase
    {
        [Flags]
        public enum FlagsEnum
        {
            UdpP2p = 1 << 0,
            UdpReflector = 1 << 1
        }

        public static int ConstructorId { get; } = -58224696;
        public int Flags { get; set; }
        public override bool UdpP2p { get; set; }
        public override bool UdpReflector { get; set; }
        public override int MinLayer { get; set; }
        public override int MaxLayer { get; set; }
        public override IList<string> LibraryVersions { get; set; }

        public override void UpdateFlags()
        {
            Flags = UdpP2p ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
            Flags = UdpReflector ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            UpdateFlags();
            writer.Write(Flags);
            writer.Write(MinLayer);
            writer.Write(MaxLayer);
            writer.Write(LibraryVersions);
        }

        public override void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            UdpP2p = FlagsHelper.IsFlagSet(Flags, 0);
            UdpReflector = FlagsHelper.IsFlagSet(Flags, 1);
            MinLayer = reader.Read<int>();
            MaxLayer = reader.Read<int>();
            LibraryVersions = reader.ReadVector<string>();
        }
    }
}