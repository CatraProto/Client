using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class DialogFilterSuggested : CatraProto.Client.TL.Schemas.CloudChats.DialogFilterSuggestedBase
	{


        public static int StaticConstructorId { get => 2004110666; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("filter")]
		public override CatraProto.Client.TL.Schemas.CloudChats.DialogFilterBase Filter { get; set; }

[JsonPropertyName("description")]
		public override string Description { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Filter);
			writer.Write(Description);

		}

		public override void Deserialize(Reader reader)
		{
			Filter = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.DialogFilterBase>();
			Description = reader.Read<string>();

		}
	}
}