using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class MessageEntityPre : CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase
	{


        public static int StaticConstructorId { get => 1938967520; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("offset")]
		public override int Offset { get; set; }

[Newtonsoft.Json.JsonProperty("length")]
		public override int Length { get; set; }

[Newtonsoft.Json.JsonProperty("language")]
		public string Language { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Offset);
			writer.Write(Length);
			writer.Write(Language);

		}

		public override void Deserialize(Reader reader)
		{
			Offset = reader.Read<int>();
			Length = reader.Read<int>();
			Language = reader.Read<string>();

		}
				
		public override string ToString()
		{
		    return "messageEntityPre";
		}
	}
}