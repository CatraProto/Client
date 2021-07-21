using System;
using System.Collections.Generic;
using CatraProto.TL;
using System.Text.Json.Serialization;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Upload
{
	public partial class GetFileHashes : IMethod
	{


        [JsonIgnore]
        public static int StaticConstructorId { get => -956147407; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.FileHashBase);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = true;

[JsonPropertyName("location")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputFileLocationBase Location { get; set; }

[JsonPropertyName("offset")]
		public int Offset { get; set; }


		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Location);
			writer.Write(Offset);

		}

		public void Deserialize(Reader reader)
		{
			Location = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputFileLocationBase>();
			Offset = reader.Read<int>();

		}
	}
}