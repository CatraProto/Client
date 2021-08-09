using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Updates
{
	public partial class State : CatraProto.Client.TL.Schemas.CloudChats.Updates.StateBase
	{


        public static int StaticConstructorId { get => -1519637954; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("pts")]
		public override int Pts { get; set; }

[JsonPropertyName("qts")]
		public override int Qts { get; set; }

[JsonPropertyName("date")]
		public override int Date { get; set; }

[JsonPropertyName("seq")]
		public override int Seq { get; set; }

[JsonPropertyName("unread_count")]
		public override int UnreadCount { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Pts);
			writer.Write(Qts);
			writer.Write(Date);
			writer.Write(Seq);
			writer.Write(UnreadCount);

		}

		public override void Deserialize(Reader reader)
		{
			Pts = reader.Read<int>();
			Qts = reader.Read<int>();
			Date = reader.Read<int>();
			Seq = reader.Read<int>();
			UnreadCount = reader.Read<int>();

		}
	}
}