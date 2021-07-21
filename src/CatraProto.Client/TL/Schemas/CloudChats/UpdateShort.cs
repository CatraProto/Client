using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdateShort : CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase
	{


        public static int StaticConstructorId { get => 2027216577; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("update")]
		public CatraProto.Client.TL.Schemas.CloudChats.UpdateBase Update { get; set; }

[JsonPropertyName("date")]
		public int Date { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Update);
			writer.Write(Date);

		}

		public override void Deserialize(Reader reader)
		{
			Update = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.UpdateBase>();
			Date = reader.Read<int>();

		}
	}
}