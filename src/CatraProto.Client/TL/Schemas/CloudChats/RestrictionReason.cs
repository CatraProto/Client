using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class RestrictionReason : CatraProto.Client.TL.Schemas.CloudChats.RestrictionReasonBase
	{


        public static int StaticConstructorId { get => -797791052; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("platform")]
		public override string Platform { get; set; }

[JsonPropertyName("reason")]
		public override string Reason { get; set; }

[JsonPropertyName("text")]
		public override string Text { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Platform);
			writer.Write(Reason);
			writer.Write(Text);

		}

		public override void Deserialize(Reader reader)
		{
			Platform = reader.Read<string>();
			Reason = reader.Read<string>();
			Text = reader.Read<string>();

		}
	}
}