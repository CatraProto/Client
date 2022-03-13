using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
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
			RequestChatBroadcast = 1 << 10,
			GeoDistance = 1 << 6,
			RequestChatTitle = 1 << 9,
			RequestChatDate = 1 << 9
		}

        public static int StaticConstructorId { get => -1525149427; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("report_spam")]
		public sealed override bool ReportSpam { get; set; }

[Newtonsoft.Json.JsonProperty("add_contact")]
		public sealed override bool AddContact { get; set; }

[Newtonsoft.Json.JsonProperty("block_contact")]
		public sealed override bool BlockContact { get; set; }

[Newtonsoft.Json.JsonProperty("share_contact")]
		public sealed override bool ShareContact { get; set; }

[Newtonsoft.Json.JsonProperty("need_contacts_exception")]
		public sealed override bool NeedContactsException { get; set; }

[Newtonsoft.Json.JsonProperty("report_geo")]
		public sealed override bool ReportGeo { get; set; }

[Newtonsoft.Json.JsonProperty("autoarchived")]
		public sealed override bool Autoarchived { get; set; }

[Newtonsoft.Json.JsonProperty("invite_members")]
		public sealed override bool InviteMembers { get; set; }

[Newtonsoft.Json.JsonProperty("request_chat_broadcast")]
		public sealed override bool RequestChatBroadcast { get; set; }

[Newtonsoft.Json.JsonProperty("geo_distance")]
		public sealed override int? GeoDistance { get; set; }

[Newtonsoft.Json.JsonProperty("request_chat_title")]
		public sealed override string RequestChatTitle { get; set; }

[Newtonsoft.Json.JsonProperty("request_chat_date")]
		public sealed override int? RequestChatDate { get; set; }


        
        public PeerSettings() 
        {
        }
		
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
			Flags = RequestChatBroadcast ? FlagsHelper.SetFlag(Flags, 10) : FlagsHelper.UnsetFlag(Flags, 10);
			Flags = GeoDistance == null ? FlagsHelper.UnsetFlag(Flags, 6) : FlagsHelper.SetFlag(Flags, 6);
			Flags = RequestChatTitle == null ? FlagsHelper.UnsetFlag(Flags, 9) : FlagsHelper.SetFlag(Flags, 9);
			Flags = RequestChatDate == null ? FlagsHelper.UnsetFlag(Flags, 9) : FlagsHelper.SetFlag(Flags, 9);

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			if(FlagsHelper.IsFlagSet(Flags, 6))
			{
				writer.Write(GeoDistance.Value);
			}

			if(FlagsHelper.IsFlagSet(Flags, 9))
			{
				writer.Write(RequestChatTitle);
			}

			if(FlagsHelper.IsFlagSet(Flags, 9))
			{
				writer.Write(RequestChatDate.Value);
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
			RequestChatBroadcast = FlagsHelper.IsFlagSet(Flags, 10);
			if(FlagsHelper.IsFlagSet(Flags, 6))
			{
				GeoDistance = reader.Read<int>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 9))
			{
				RequestChatTitle = reader.Read<string>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 9))
			{
				RequestChatDate = reader.Read<int>();
			}


		}
				
		public override string ToString()
		{
		    return "peerSettings";
		}
	}
}