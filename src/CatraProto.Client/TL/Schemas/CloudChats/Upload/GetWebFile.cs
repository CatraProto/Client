using System;
using System.Collections.Generic;
using CatraProto.TL;
using System.Text.Json.Serialization;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Upload
{
	public partial class GetWebFile : IMethod
	{


        [JsonIgnore]
        public static int StaticConstructorId { get => 619086221; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Upload.WebFileBase);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[JsonPropertyName("location")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputWebFileLocationBase Location { get; set; }

[JsonPropertyName("offset")]
		public int Offset { get; set; }

[JsonPropertyName("limit")]
		public int Limit { get; set; }


		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Location);
			writer.Write(Offset);
			writer.Write(Limit);

		}

		public void Deserialize(Reader reader)
		{
			Location = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputWebFileLocationBase>();
			Offset = reader.Read<int>();
			Limit = reader.Read<int>();

		}
	}
}