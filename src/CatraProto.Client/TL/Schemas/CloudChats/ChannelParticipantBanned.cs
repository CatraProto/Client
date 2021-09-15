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

        public static int StaticConstructorId { get => 470789295; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("left")]
		public bool Left { get; set; }

[Newtonsoft.Json.JsonProperty("user_id")]
		public override int UserId { get; set; }

[Newtonsoft.Json.JsonProperty("kicked_by")]
		public int KickedBy { get; set; }

[Newtonsoft.Json.JsonProperty("date")]
		public int Date { get; set; }

[Newtonsoft.Json.JsonProperty("banned_rights")]
		public CatraProto.Client.TL.Schemas.CloudChats.ChatBannedRightsBase BannedRights { get; set; }

        
		public override void UpdateFlags() 
		{
			Flags = Left ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(UserId);
			writer.Write(KickedBy);
			writer.Write(Date);
			writer.Write(BannedRights);

		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Left = FlagsHelper.IsFlagSet(Flags, 0);
			UserId = reader.Read<int>();
			KickedBy = reader.Read<int>();
			Date = reader.Read<int>();
			BannedRights = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.ChatBannedRightsBase>();

		}
				
		public override string ToString()
		{
		    return "channelParticipantBanned";
		}
	}
}