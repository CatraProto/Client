using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdateDeleteChannelMessages : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
	{


        public static int StaticConstructorId { get => -1015733815; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("channel_id")]
		public int ChannelId { get; set; }

[JsonPropertyName("messages")]
		public IList<int> Messages { get; set; }

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
			writer.Write(ChannelId);
			writer.Write(Messages);
			writer.Write(Pts);
			writer.Write(PtsCount);

		}

		public override void Deserialize(Reader reader)
		{
			ChannelId = reader.Read<int>();
			Messages = reader.ReadVector<int>();
			Pts = reader.Read<int>();
			PtsCount = reader.Read<int>();

		}
	}
}