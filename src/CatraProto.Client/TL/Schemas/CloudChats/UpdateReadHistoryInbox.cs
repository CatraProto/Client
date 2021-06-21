using System;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class UpdateReadHistoryInbox : UpdateBase
    {
        public static int ConstructorId { get; } = -1667805217;
        public int Flags { get; set; }
        public int? FolderId { get; set; }
        public PeerBase Peer { get; set; }
        public int MaxId { get; set; }
        public int StillUnreadCount { get; set; }
        public int Pts { get; set; }
        public int PtsCount { get; set; }

        [Flags]
        public enum FlagsEnum
        {
            FolderId = 1 << 0
        }

        public override void UpdateFlags()
        {
            Flags = FolderId == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            UpdateFlags();
            writer.Write(Flags);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                writer.Write(FolderId.Value);
            }

            writer.Write(Peer);
            writer.Write(MaxId);
            writer.Write(StillUnreadCount);
            writer.Write(Pts);
            writer.Write(PtsCount);
        }

        public override void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                FolderId = reader.Read<int>();
            }

            Peer = reader.Read<PeerBase>();
            MaxId = reader.Read<int>();
            StillUnreadCount = reader.Read<int>();
            Pts = reader.Read<int>();
            PtsCount = reader.Read<int>();
        }
    }
}