using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class ChannelAdminLogEventActionParticipantInvite : CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEventActionBase
	{


        public static int StaticConstructorId { get => -484690728; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("participant")]
		public CatraProto.Client.TL.Schemas.CloudChats.ChannelParticipantBase Participant { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Participant);

		}

		public override void Deserialize(Reader reader)
		{
			Participant = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.ChannelParticipantBase>();

		}
	}
}