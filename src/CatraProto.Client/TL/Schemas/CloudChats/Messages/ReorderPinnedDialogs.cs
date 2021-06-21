using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class ReorderPinnedDialogs : IMethod
    {
        public static int ConstructorId { get; } = 991616823;
        public int Flags { get; set; }
        public bool Force { get; set; }
        public int FolderId { get; set; }
        public IList<InputDialogPeerBase> Order { get; set; }

        public Type Type { get; init; } = typeof(bool);
        public bool IsVector { get; init; } = false;

        [Flags]
        public enum FlagsEnum
        {
            Force = 1 << 0
        }

        public void UpdateFlags()
        {
            Flags = Force ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
        }

        public void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            UpdateFlags();
            writer.Write(Flags);
            writer.Write(FolderId);
            writer.Write(Order);
        }

        public void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            Force = FlagsHelper.IsFlagSet(Flags, 0);
            FolderId = reader.Read<int>();
            Order = reader.ReadVector<InputDialogPeerBase>();
        }
    }
}