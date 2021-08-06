using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Channels
{
	public partial class ChannelParticipant : CatraProto.Client.TL.Schemas.CloudChats.Channels.ChannelParticipantBase
	{


        public static int StaticConstructorId { get => -791039645; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("participant")]
		public override CatraProto.Client.TL.Schemas.CloudChats.ChannelParticipantBase Participant { get; set; }

[JsonPropertyName("users")]
		public override IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Participant);
			writer.Write(Users);

		}

		public override void Deserialize(Reader reader)
		{
			Participant = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.ChannelParticipantBase>();
			Users = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.UserBase>();

		}
	}
}