using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputFileBig : CatraProto.Client.TL.Schemas.CloudChats.InputFileBase
	{


        public static int StaticConstructorId { get => -95482955; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("id")]
		public override long Id { get; set; }

[Newtonsoft.Json.JsonProperty("parts")]
		public override int Parts { get; set; }

[Newtonsoft.Json.JsonProperty("name")]
		public override string Name { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Id);
			writer.Write(Parts);
			writer.Write(Name);

		}

		public override void Deserialize(Reader reader)
		{
			Id = reader.Read<long>();
			Parts = reader.Read<int>();
			Name = reader.Read<string>();

		}
				
		public override string ToString()
		{
		    return "inputFileBig";
		}
	}
}