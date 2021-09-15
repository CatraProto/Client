using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class ChatFull : CatraProto.Client.TL.Schemas.CloudChats.ChatFullBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			CanSetUsername = 1 << 7,
			HasScheduled = 1 << 8,
			ChatPhoto = 1 << 2,
			BotInfo = 1 << 3,
			PinnedMsgId = 1 << 6,
			FolderId = 1 << 11
		}

        public static int StaticConstructorId { get => 461151667; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("can_set_username")]
		public bool CanSetUsername { get; set; }

[Newtonsoft.Json.JsonProperty("has_scheduled")]
		public bool HasScheduled { get; set; }

[Newtonsoft.Json.JsonProperty("id")]
		public override int Id { get; set; }

[Newtonsoft.Json.JsonProperty("about")]
		public override string About { get; set; }

[Newtonsoft.Json.JsonProperty("participants")]
		public CatraProto.Client.TL.Schemas.CloudChats.ChatParticipantsBase Participants { get; set; }

[Newtonsoft.Json.JsonProperty("chat_photo")]
		public CatraProto.Client.TL.Schemas.CloudChats.PhotoBase ChatPhoto { get; set; }

[Newtonsoft.Json.JsonProperty("notify_settings")]
		public override CatraProto.Client.TL.Schemas.CloudChats.PeerNotifySettingsBase NotifySettings { get; set; }

[Newtonsoft.Json.JsonProperty("exported_invite")]
		public override CatraProto.Client.TL.Schemas.CloudChats.ExportedChatInviteBase ExportedInvite { get; set; }

[Newtonsoft.Json.JsonProperty("bot_info")]
		public IList<CatraProto.Client.TL.Schemas.CloudChats.BotInfoBase> BotInfo { get; set; }

[Newtonsoft.Json.JsonProperty("pinned_msg_id")]
		public int? PinnedMsgId { get; set; }

[Newtonsoft.Json.JsonProperty("folder_id")]
		public override int? FolderId { get; set; }

        
		public override void UpdateFlags() 
		{
			Flags = CanSetUsername ? FlagsHelper.SetFlag(Flags, 7) : FlagsHelper.UnsetFlag(Flags, 7);
			Flags = HasScheduled ? FlagsHelper.SetFlag(Flags, 8) : FlagsHelper.UnsetFlag(Flags, 8);
			Flags = ChatPhoto == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
			Flags = BotInfo == null ? FlagsHelper.UnsetFlag(Flags, 3) : FlagsHelper.SetFlag(Flags, 3);
			Flags = PinnedMsgId == null ? FlagsHelper.UnsetFlag(Flags, 6) : FlagsHelper.SetFlag(Flags, 6);
			Flags = FolderId == null ? FlagsHelper.UnsetFlag(Flags, 11) : FlagsHelper.SetFlag(Flags, 11);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Id);
			writer.Write(About);
			writer.Write(Participants);
			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				writer.Write(ChatPhoto);
			}

			writer.Write(NotifySettings);
			writer.Write(ExportedInvite);
			if(FlagsHelper.IsFlagSet(Flags, 3))
			{
				writer.Write(BotInfo);
			}

			if(FlagsHelper.IsFlagSet(Flags, 6))
			{
				writer.Write(PinnedMsgId.Value);
			}

			if(FlagsHelper.IsFlagSet(Flags, 11))
			{
				writer.Write(FolderId.Value);
			}


		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			CanSetUsername = FlagsHelper.IsFlagSet(Flags, 7);
			HasScheduled = FlagsHelper.IsFlagSet(Flags, 8);
			Id = reader.Read<int>();
			About = reader.Read<string>();
			Participants = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.ChatParticipantsBase>();
			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				ChatPhoto = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.PhotoBase>();
			}

			NotifySettings = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.PeerNotifySettingsBase>();
			ExportedInvite = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.ExportedChatInviteBase>();
			if(FlagsHelper.IsFlagSet(Flags, 3))
			{
				BotInfo = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.BotInfoBase>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 6))
			{
				PinnedMsgId = reader.Read<int>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 11))
			{
				FolderId = reader.Read<int>();
			}


		}
				
		public override string ToString()
		{
		    return "chatFull";
		}
	}
}