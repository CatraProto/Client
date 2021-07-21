using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class ChannelAdminLogEventActionParticipantToggleBan : CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEventActionBase
	{


        public static int StaticConstructorId { get => -422036098; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("prev_participant")]
		public CatraProto.Client.TL.Schemas.CloudChats.ChannelParticipantBase PrevParticipant { get; set; }

[JsonPropertyName("new_participant")]
		public CatraProto.Client.TL.Schemas.CloudChats.ChannelParticipantBase NewParticipant { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(PrevParticipant);
			writer.Write(NewParticipant);

		}

		public override void Deserialize(Reader reader)
		{
			PrevParticipant = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.ChannelParticipantBase>();
			NewParticipant = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.ChannelParticipantBase>();

		}
	}
}