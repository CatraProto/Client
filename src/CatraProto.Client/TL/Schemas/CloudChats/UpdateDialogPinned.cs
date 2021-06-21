using System;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class UpdateDialogPinned : UpdateBase
    {
        public static int ConstructorId { get; } = 1852826908;
        public int Flags { get; set; }
        public bool Pinned { get; set; }
        public int? FolderId { get; set; }
        public DialogPeerBase Peer { get; set; }

        [Flags]
        public enum FlagsEnum
        {
            Pinned = 1 << 0,
            FolderId = 1 << 1
        }

        public override void UpdateFlags()
        {
            Flags = Pinned ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
            Flags = FolderId == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            UpdateFlags();
            writer.Write(Flags);
            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                writer.Write(FolderId.Value);
            }

            writer.Write(Peer);
        }

        public override void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            Pinned = FlagsHelper.IsFlagSet(Flags, 0);
            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                FolderId = reader.Read<int>();
            }

            Peer = reader.Read<DialogPeerBase>();
        }
    }
}