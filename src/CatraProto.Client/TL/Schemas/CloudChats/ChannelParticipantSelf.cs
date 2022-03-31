using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class ChannelParticipantSelf : CatraProto.Client.TL.Schemas.CloudChats.ChannelParticipantBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			ViaRequest = 1 << 0
		}

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 900251559; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("via_request")]
		public bool ViaRequest { get; set; }

[Newtonsoft.Json.JsonProperty("user_id")]
		public long UserId { get; set; }

[Newtonsoft.Json.JsonProperty("inviter_id")]
		public long InviterId { get; set; }

[Newtonsoft.Json.JsonProperty("date")]
		public int Date { get; set; }


        #nullable enable
 public ChannelParticipantSelf (long userId,long inviterId,int date)
{
 UserId = userId;
InviterId = inviterId;
Date = date;
 
}
#nullable disable
        internal ChannelParticipantSelf() 
        {
        }
		
		public override void UpdateFlags() 
		{
			Flags = ViaRequest ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(UserId);
			writer.Write(InviterId);
			writer.Write(Date);

		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			ViaRequest = FlagsHelper.IsFlagSet(Flags, 0);
			UserId = reader.Read<long>();
			InviterId = reader.Read<long>();
			Date = reader.Read<int>();

		}
		
		public override string ToString()
		{
		    return "channelParticipantSelf";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}