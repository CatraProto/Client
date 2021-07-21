using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class PopularContact : CatraProto.Client.TL.Schemas.CloudChats.PopularContactBase
	{


        public static int StaticConstructorId { get => 1558266229; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("client_id")]
		public override long ClientId { get; set; }

[JsonPropertyName("importers")]
		public override int Importers { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(ClientId);
			writer.Write(Importers);

		}

		public override void Deserialize(Reader reader)
		{
			ClientId = reader.Read<long>();
			Importers = reader.Read<int>();

		}
	}
}