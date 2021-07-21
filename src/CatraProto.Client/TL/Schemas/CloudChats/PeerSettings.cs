using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class PeerSettings : CatraProto.Client.TL.Schemas.CloudChats.PeerSettingsBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			ReportSpam = 1 << 0,
			AddContact = 1 << 1,
			BlockContact = 1 << 2,
			ShareContact = 1 << 3,
			NeedContactsException = 1 << 4,
			ReportGeo = 1 << 5,
			Autoarchived = 1 << 7,
			InviteMembers = 1 << 8,
			GeoDistance = 1 << 6
		}

        public static int StaticConstructorId { get => 1933519201; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		public int Flags { get; set; }

[JsonPropertyName("report_spam")]
		public override bool ReportSpam { get; set; }

[JsonPropertyName("add_contact")]
		public override bool AddContact { get; set; }

[JsonPropertyName("block_contact")]
		public override bool BlockContact { get; set; }

[JsonPropertyName("share_contact")]
		public override bool ShareContact { get; set; }

[JsonPropertyName("need_contacts_exception")]
		public override bool NeedContactsException { get; set; }

[JsonPropertyName("report_geo")]
		public override bool ReportGeo { get; set; }

[JsonPropertyName("autoarchived")]
		public override bool Autoarchived { get; set; }

[JsonPropertyName("invite_members")]
		public override bool InviteMembers { get; set; }

[JsonPropertyName("geo_distance")]
		public override int? GeoDistance { get; set; }

        
		public override void UpdateFlags() 
		{
			Flags = ReportSpam ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
			Flags = AddContact ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
			Flags = BlockContact ? FlagsHelper.SetFlag(Flags, 2) : FlagsHelper.UnsetFlag(Flags, 2);
			Flags = ShareContact ? FlagsHelper.SetFlag(Flags, 3) : FlagsHelper.UnsetFlag(Flags, 3);
			Flags = NeedContactsException ? FlagsHelper.SetFlag(Flags, 4) : FlagsHelper.UnsetFlag(Flags, 4);
			Flags = ReportGeo ? FlagsHelper.SetFlag(Flags, 5) : FlagsHelper.UnsetFlag(Flags, 5);
			Flags = Autoarchived ? FlagsHelper.SetFlag(Flags, 7) : FlagsHelper.UnsetFlag(Flags, 7);
			Flags = InviteMembers ? FlagsHelper.SetFlag(Flags, 8) : FlagsHelper.UnsetFlag(Flags, 8);
			Flags = GeoDistance == null ? FlagsHelper.UnsetFlag(Flags, 6) : FlagsHelper.SetFlag(Flags, 6);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			if(FlagsHelper.IsFlagSet(Flags, 6))
			{
				writer.Write(GeoDistance.Value);
			}


		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			ReportSpam = FlagsHelper.IsFlagSet(Flags, 0);
			AddContact = FlagsHelper.IsFlagSet(Flags, 1);
			BlockContact = FlagsHelper.IsFlagSet(Flags, 2);
			ShareContact = FlagsHelper.IsFlagSet(Flags, 3);
			NeedContactsException = FlagsHelper.IsFlagSet(Flags, 4);
			ReportGeo = FlagsHelper.IsFlagSet(Flags, 5);
			Autoarchived = FlagsHelper.IsFlagSet(Flags, 7);
			InviteMembers = FlagsHelper.IsFlagSet(Flags, 8);
			if(FlagsHelper.IsFlagSet(Flags, 6))
			{
				GeoDistance = reader.Read<int>();
			}


		}
	}
}