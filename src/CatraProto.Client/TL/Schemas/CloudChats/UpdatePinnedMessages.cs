using System;
using System.Collections.Generic;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class UpdatePinnedMessages : UpdateBase
    {
        public static int ConstructorId { get; } = -309990731;
        public int Flags { get; set; }
        public bool Pinned { get; set; }
        public PeerBase Peer { get; set; }
        public IList<int> Messages { get; set; }
        public int Pts { get; set; }
        public int PtsCount { get; set; }

        [Flags]
        public enum FlagsEnum
        {
            Pinned = 1 << 0
        }

        public override void UpdateFlags()
        {
            Flags = Pinned ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            UpdateFlags();
            writer.Write(Flags);
            writer.Write(Peer);
            writer.Write(Messages);
            writer.Write(Pts);
            writer.Write(PtsCount);
        }

        public override void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            Pinned = FlagsHelper.IsFlagSet(Flags, 0);
            Peer = reader.Read<PeerBase>();
            Messages = reader.ReadVector<int>();
            Pts = reader.Read<int>();
            PtsCount = reader.Read<int>();
        }
    }
}