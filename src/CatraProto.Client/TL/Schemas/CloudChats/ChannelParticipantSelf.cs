using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class ChannelParticipantSelf : CatraProto.Client.TL.Schemas.CloudChats.ChannelParticipantBase
	{


        public static int StaticConstructorId { get => -1557620115; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("user_id")]
		public override int UserId { get; set; }

[JsonPropertyName("inviter_id")]
		public int InviterId { get; set; }

[JsonPropertyName("date")]
		public int Date { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(UserId);
			writer.Write(InviterId);
			writer.Write(Date);

		}

		public override void Deserialize(Reader reader)
		{
			UserId = reader.Read<int>();
			InviterId = reader.Read<int>();
			Date = reader.Read<int>();

		}
	}
}