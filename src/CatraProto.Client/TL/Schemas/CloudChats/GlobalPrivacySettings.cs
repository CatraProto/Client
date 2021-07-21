using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class GlobalPrivacySettings : CatraProto.Client.TL.Schemas.CloudChats.GlobalPrivacySettingsBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			ArchiveAndMuteNewNoncontactPeers = 1 << 0
		}

        public static int StaticConstructorId { get => -1096616924; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		public int Flags { get; set; }

[JsonPropertyName("archive_and_mute_new_noncontact_peers")]
		public override bool? ArchiveAndMuteNewNoncontactPeers { get; set; }

        
		public override void UpdateFlags() 
		{
			Flags = ArchiveAndMuteNewNoncontactPeers == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
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