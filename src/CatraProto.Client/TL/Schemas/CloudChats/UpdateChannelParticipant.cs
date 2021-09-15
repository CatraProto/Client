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
			NewParticipant = 1 << 1
		}

        public static int StaticConstructorId { get => 1708307556; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("channel_id")]
		public int ChannelId { get; set; }

[Newtonsoft.Json.JsonProperty("date")]
		public int Date { get; set; }

[Newtonsoft.Json.JsonProperty("user_id")]
		public int UserId { get; set; }

[Newtonsoft.Json.JsonProperty("prev_participant")]
		public CatraProto.Client.TL.Schemas.CloudChats.ChannelParticipantBase PrevParticipant { get; set; }

[Newtonsoft.Json.JsonProperty("new_participant")]
		public CatraProto.Client.TL.Schemas.CloudChats.ChannelParticipantBase NewParticipant { get; set; }

[Newtonsoft.Json.JsonProperty("qts")]
		public int Qts { get; set; }

        
		public override void UpdateFlags() 
		{
			Flags = PrevParticipant == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
			Flags = NewParticipant == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(ChannelId);
			writer.Write(Date);
			writer.Write(UserId);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(PrevParticipant);
			}

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				writer.Write(NewParticipant);
			}

			writer.Write(Qts);

		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			ChannelId = reader.Read<int>();
			Date = reader.Read<int>();
			UserId = reader.Read<int>();
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				PrevParticipant = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.ChannelParticipantBase>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				NewParticipant = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.ChannelParticipantBase>();
			}

			Qts = reader.Read<int>();

		}
				
		public override string ToString()
		{
		    return "updateChannelParticipant";
		}
	}
}