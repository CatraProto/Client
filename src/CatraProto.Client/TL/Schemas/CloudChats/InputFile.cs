using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputFile : CatraProto.Client.TL.Schemas.CloudChats.InputFileBase
	{


        public static int StaticConstructorId { get => -181407105; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("id")]
		public override long Id { get; set; }

[JsonPropertyName("parts")]
		public override int Parts { get; set; }

[JsonPropertyName("name")]
		public override string Name { get; set; }

[JsonPropertyName("md5_checksum")]
		public string Md5Checksum { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Id);
			writer.Write(Parts);
			writer.Write(Name);
			writer.Write(Md5Checksum);

		}

		public override void Deserialize(Reader reader)
		{
			Id = reader.Read<long>();
			Parts = reader.Read<int>();
			Name = reader.Read<string>();
			Md5Checksum = reader.Read<string>();

		}
	}
}