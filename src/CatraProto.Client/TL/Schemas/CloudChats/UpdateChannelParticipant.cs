using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdateChannelParticipant : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			PrevParticipant = 1 << 0,
			NewParticipant = 1 << 1,
			Invite = 1 << 2
		}

        public static int StaticConstructorId { get => -1738720581; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("channel_id")]
		public long ChannelId { get; set; }

[Newtonsoft.Json.JsonProperty("date")]
		public int Date { get; set; }

[Newtonsoft.Json.JsonProperty("actor_id")]
		public long ActorId { get; set; }

[Newtonsoft.Json.JsonProperty("user_id")]
		public long UserId { get; set; }

[Newtonsoft.Json.JsonProperty("prev_participant")]
		public CatraProto.Client.TL.Schemas.CloudChats.ChannelParticipantBase PrevParticipant { get; set; }

[Newtonsoft.Json.JsonProperty("new_participant")]
		public CatraProto.Client.TL.Schemas.CloudChats.ChannelParticipantBase NewParticipant { get; set; }

[Newtonsoft.Json.JsonProperty("invite")]
		public CatraProto.Client.TL.Schemas.CloudChats.ExportedChatInviteBase Invite { get; set; }

[Newtonsoft.Json.JsonProperty("qts")]
		public int Qts { get; set; }


        #nullable enable
 public UpdateChannelParticipant (long channelId,int date,long actorId,long userId,int qts)
{
 ChannelId = channelId;
Date = date;
ActorId = actorId;
UserId = userId;
Qts = qts;
 
}
#nullable disable
        internal UpdateChannelParticipant() 
        {
        }
		
		public override void UpdateFlags() 
		{
			Flags = PrevParticipant == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
			Flags = NewParticipant == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
			Flags = Invite == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(ChannelId);
			writer.Write(Date);
			writer.Write(ActorId);
			writer.Write(UserId);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(PrevParticipant);
			}

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				writer.Write(NewParticipant);
			}

			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				writer.Write(Invite);
			}

			writer.Write(Qts);

		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			ChannelId = reader.Read<long>();
			Date = reader.Read<int>();
			ActorId = reader.Read<long>();
			UserId = reader.Read<long>();
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				PrevParticipant = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.ChannelParticipantBase>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				NewParticipant = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.ChannelParticipantBase>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				Invite = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.ExportedChatInviteBase>();
			}

			Qts = reader.Read<int>();

		}
				
		public override string ToString()
		{
		    return "updateChannelParticipant";
		}
	}
}