using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Auth
{
	public partial class SentCodeTypeFlashCall : CatraProto.Client.TL.Schemas.CloudChats.Auth.SentCodeTypeBase
	{


        public static int StaticConstructorId { get => -1425815847; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("pattern")]
		public string Pattern { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Pattern);

		}

		public override void Deserialize(Reader reader)
		{
			Pattern = reader.Read<string>();

		}
	}
}