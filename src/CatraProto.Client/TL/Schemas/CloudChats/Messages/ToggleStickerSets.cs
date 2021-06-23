using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public class ToggleStickerSets : IMethod
    {
        [Flags]
        public enum FlagsEnum
        {
            Uninstall = 1 << 0,
            Archive = 1 << 1,
            Unarchive = 1 << 2
        }

        public static int ConstructorId { get; } = -1257951254;

        public System.Type Type { get; init; } = typeof(bool);
        public bool IsVector { get; init; } = false;
        public int Flags { get; set; }
        public bool Uninstall { get; set; }
        public bool Archive { get; set; }
        public bool Unarchive { get; set; }
        public IList<InputStickerSetBase> Stickersets { get; set; }

        public void UpdateFlags()
        {
            Flags = Uninstall ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
            Flags = Archive ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
            Flags = Unarchive ? FlagsHelper.SetFlag(Flags, 2) : FlagsHelper.UnsetFlag(Flags, 2);
        }

        public void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            UpdateFlags();
            writer.Write(Flags);
            writer.Write(Stickersets);
        }

        public void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            Uninstall = FlagsHelper.IsFlagSet(Flags, 0);
            Archive = FlagsHelper.IsFlagSet(Flags, 1);
            Unarchive = FlagsHelper.IsFlagSet(Flags, 2);
            Stickersets = reader.ReadVector<InputStickerSetBase>();
        }
    }
}