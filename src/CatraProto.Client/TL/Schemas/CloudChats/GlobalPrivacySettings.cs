using System;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class GlobalPrivacySettings : GlobalPrivacySettingsBase
    {
        [Flags]
        public enum FlagsEnum
        {
            ArchiveAndMuteNewNoncontactPeers = 1 << 0
        }

        public static int ConstructorId { get; } = -1096616924;
        public int Flags { get; set; }
        public override bool? ArchiveAndMuteNewNoncontactPeers { get; set; }

        public override void UpdateFlags()
        {
            Flags = ArchiveAndMuteNewNoncontactPeers == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            UpdateFlags();
            writer.Write(Flags);
            writer.Write(ArchiveAndMuteNewNoncontactPeers.Value);
        }

        public override void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            ArchiveAndMuteNewNoncontactPeers = reader.Read<bool>();
        }
    }
}