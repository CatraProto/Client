using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdateEditChannelMessage : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
	{


        public static int StaticConstructorId { get => 457133559; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("message")]
		public CatraProto.Client.TL.Schemas.CloudChats.MessageBase Message { get; set; }

[JsonPropertyName("pts")]
		public int Pts { get; set; }

[JsonPropertyName("pts_count")]
		public int PtsCount { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Message);
			writer.Write(Pts);
			writer.Write(PtsCount);

		}

		public override void Deserialize(Reader reader)
		{
			Message = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.MessageBase>();
			Pts = reader.Read<int>();
			PtsCount = reader.Read<int>();

		}
	}
}