using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
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
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("archive_and_mute_new_noncontact_peers")]
		public sealed override bool? ArchiveAndMuteNewNoncontactPeers { get; set; }


        
        public GlobalPrivacySettings() 
        {
        }
		
		public override void UpdateFlags() 
		{
			Flags = ArchiveAndMuteNewNoncontactPeers == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(ArchiveAndMuteNewNoncontactPeers.Value);

		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
			ArchiveAndMuteNewNoncontactPeers = reader.Read<bool>();
			}


		}
				
		public override string ToString()
		{
		    return "globalPrivacySettings";
		}
	}
}