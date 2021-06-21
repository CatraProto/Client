using System;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class UpdateDialogUnreadMark : UpdateBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Unread = 1 << 0
        }

        public static int ConstructorId { get; } = -513517117;
        public int Flags { get; set; }
        public bool Unread { get; set; }
        public DialogPeerBase Peer { get; set; }

        public override void UpdateFlags()
        {
            Flags = Unread ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            UpdateFlags();
            writer.Write(Flags);
            writer.Write(Peer);
        }

        public override void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            Unread = FlagsHelper.IsFlagSet(Flags, 0);
            Peer = reader.Read<DialogPeerBase>();
        }
    }
}