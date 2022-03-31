using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class ChannelParticipantBanned : CatraProto.Client.TL.Schemas.CloudChats.ChannelParticipantBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Left = 1 << 0
		}

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1844969806; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("left")]
		public bool Left { get; set; }

[Newtonsoft.Json.JsonProperty("peer")]
		public CatraProto.Client.TL.Schemas.CloudChats.PeerBase Peer { get; set; }

[Newtonsoft.Json.JsonProperty("kicked_by")]
		public long KickedBy { get; set; }

[Newtonsoft.Json.JsonProperty("date")]
		public int Date { get; set; }

[Newtonsoft.Json.JsonProperty("banned_rights")]
		public CatraProto.Client.TL.Schemas.CloudChats.ChatBannedRightsBase BannedRights { get; set; }


        #nullable enable
 public ChannelParticipantBanned (CatraProto.Client.TL.Schemas.CloudChats.PeerBase peer,long kickedBy,int date,CatraProto.Client.TL.Schemas.CloudChats.ChatBannedRightsBase bannedRights)
{
 Peer = peer;
KickedBy = kickedBy;
Date = date;
BannedRights = bannedRights;
 
}
#nullable disable
        internal ChannelParticipantBanned() 
        {
        }
		
		public override void UpdateFlags() 
		{
			Flags = Left ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Peer);
			writer.Write(KickedBy);
			writer.Write(Date);
			writer.Write(BannedRights);

		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Left = FlagsHelper.IsFlagSet(Flags, 0);
			Peer = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.PeerBase>();
			KickedBy = reader.Read<long>();
			Date = reader.Read<int>();
			BannedRights = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.ChatBannedRightsBase>();

		}
		
		public override string ToString()
		{
		    return "channelParticipantBanned";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}