using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class GetDialogs : IMethod
    {
        [Flags]
        public enum FlagsEnum
        {
            ExcludePinned = 1 << 0,
            FolderId = 1 << 1
        }

        public static int ConstructorId { get; } = -1594999949;
        public int Flags { get; set; }
        public bool ExcludePinned { get; set; }
        public int? FolderId { get; set; }
        public int OffsetDate { get; set; }
        public int OffsetId { get; set; }
        public InputPeerBase OffsetPeer { get; set; }
        public int Limit { get; set; }
        public int Hash { get; set; }

        public Type Type { get; init; } = typeof(DialogsBase);
        public bool IsVector { get; init; } = false;

        public void UpdateFlags()
        {
            Flags = ExcludePinned ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
            Flags = FolderId == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
        }

        public void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            UpdateFlags();
            writer.Write(Flags);
            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                writer.Write(FolderId.Value);
            }

            writer.Write(OffsetDate);
            writer.Write(OffsetId);
            writer.Write(OffsetPeer);
            writer.Write(Limit);
            writer.Write(Hash);
        }

        public void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            ExcludePinned = FlagsHelper.IsFlagSet(Flags, 0);
            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                FolderId = reader.Read<int>();
            }

            OffsetDate = reader.Read<int>();
            OffsetId = reader.Read<int>();
            OffsetPeer = reader.Read<InputPeerBase>();
            Limit = reader.Read<int>();
            Hash = reader.Read<int>();
        }
    }
}