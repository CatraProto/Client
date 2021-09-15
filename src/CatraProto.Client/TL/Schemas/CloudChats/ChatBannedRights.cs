using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class ChatBannedRights : CatraProto.Client.TL.Schemas.CloudChats.ChatBannedRightsBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			ViewMessages = 1 << 0,
			SendMessages = 1 << 1,
			SendMedia = 1 << 2,
			SendStickers = 1 << 3,
			SendGifs = 1 << 4,
			SendGames = 1 << 5,
			SendInline = 1 << 6,
			EmbedLinks = 1 << 7,
			SendPolls = 1 << 8,
			ChangeInfo = 1 << 10,
			InviteUsers = 1 << 15,
			PinMessages = 1 << 17
		}

        public static int StaticConstructorId { get => -1626209256; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("view_messages")]
		public override bool ViewMessages { get; set; }

[Newtonsoft.Json.JsonProperty("send_messages")]
		public override bool SendMessages { get; set; }

[Newtonsoft.Json.JsonProperty("send_media")]
		public override bool SendMedia { get; set; }

[Newtonsoft.Json.JsonProperty("send_stickers")]
		public override bool SendStickers { get; set; }

[Newtonsoft.Json.JsonProperty("send_gifs")]
		public override bool SendGifs { get; set; }

[Newtonsoft.Json.JsonProperty("send_games")]
		public override bool SendGames { get; set; }

[Newtonsoft.Json.JsonProperty("send_inline")]
		public override bool SendInline { get; set; }

[Newtonsoft.Json.JsonProperty("embed_links")]
		public override bool EmbedLinks { get; set; }

[Newtonsoft.Json.JsonProperty("send_polls")]
		public override bool SendPolls { get; set; }

[Newtonsoft.Json.JsonProperty("change_info")]
		public override bool ChangeInfo { get; set; }

[Newtonsoft.Json.JsonProperty("invite_users")]
		public override bool InviteUsers { get; set; }

[Newtonsoft.Json.JsonProperty("pin_messages")]
		public override bool PinMessages { get; set; }

[Newtonsoft.Json.JsonProperty("until_date")]
		public override int UntilDate { get; set; }

        
		public override void UpdateFlags() 
		{
			Flags = ViewMessages ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
			Flags = SendMessages ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
			Flags = SendMedia ? FlagsHelper.SetFlag(Flags, 2) : FlagsHelper.UnsetFlag(Flags, 2);
			Flags = SendStickers ? FlagsHelper.SetFlag(Flags, 3) : FlagsHelper.UnsetFlag(Flags, 3);
			Flags = SendGifs ? FlagsHelper.SetFlag(Flags, 4) : FlagsHelper.UnsetFlag(Flags, 4);
			Flags = SendGames ? FlagsHelper.SetFlag(Flags, 5) : FlagsHelper.UnsetFlag(Flags, 5);
			Flags = SendInline ? FlagsHelper.SetFlag(Flags, 6) : FlagsHelper.UnsetFlag(Flags, 6);
			Flags = EmbedLinks ? FlagsHelper.SetFlag(Flags, 7) : FlagsHelper.UnsetFlag(Flags, 7);
			Flags = SendPolls ? FlagsHelper.SetFlag(Flags, 8) : FlagsHelper.UnsetFlag(Flags, 8);
			Flags = ChangeInfo ? FlagsHelper.SetFlag(Flags, 10) : FlagsHelper.UnsetFlag(Flags, 10);
			Flags = InviteUsers ? FlagsHelper.SetFlag(Flags, 15) : FlagsHelper.UnsetFlag(Flags, 15);
			Flags = PinMessages ? FlagsHelper.SetFlag(Flags, 17) : FlagsHelper.UnsetFlag(Flags, 17);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(UntilDate);

		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			ViewMessages = FlagsHelper.IsFlagSet(Flags, 0);
			SendMessages = FlagsHelper.IsFlagSet(Flags, 1);
			SendMedia = FlagsHelper.IsFlagSet(Flags, 2);
			SendStickers = FlagsHelper.IsFlagSet(Flags, 3);
			SendGifs = FlagsHelper.IsFlagSet(Flags, 4);
			SendGames = FlagsHelper.IsFlagSet(Flags, 5);
			SendInline = FlagsHelper.IsFlagSet(Flags, 6);
			EmbedLinks = FlagsHelper.IsFlagSet(Flags, 7);
			SendPolls = FlagsHelper.IsFlagSet(Flags, 8);
			ChangeInfo = FlagsHelper.IsFlagSet(Flags, 10);
			InviteUsers = FlagsHelper.IsFlagSet(Flags, 15);
			PinMessages = FlagsHelper.IsFlagSet(Flags, 17);
			UntilDate = reader.Read<int>();

		}
				
		public override string ToString()
		{
		    return "chatBannedRights";
		}
	}
}