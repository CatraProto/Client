using System;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class UpdateReadChannelInbox : UpdateBase
    {
        [Flags]
        public enum FlagsEnum
        {
            FolderId = 1 << 0
        }

        public static int ConstructorId { get; } = 856380452;
        public int Flags { get; set; }
        public int? FolderId { get; set; }
        public int ChannelId { get; set; }
        public int MaxId { get; set; }
        public int StillUnreadCount { get; set; }
        public int Pts { get; set; }

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

            writer.Write(ChannelId);
            writer.Write(MaxId);
            writer.Write(StillUnreadCount);
            writer.Write(Pts);
        }

        public override void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                FolderId = reader.Read<int>();
            }

            ChannelId = reader.Read<int>();
            MaxId = reader.Read<int>();
            StillUnreadCount = reader.Read<int>();
            Pts = reader.Read<int>();
        }
    }
}