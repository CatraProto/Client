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


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1938967520; }
        
[Newtonsoft.Json.JsonProperty("offset")]
		public sealed override int Offset { get; set; }

[Newtonsoft.Json.JsonProperty("length")]
		public sealed override int Length { get; set; }

[Newtonsoft.Json.JsonProperty("language")]
		public string Language { get; set; }


        #nullable enable
 public MessageEntityPre (int offset,int length,string language)
{
 Offset = offset;
Length = length;
Language = language;
 
}
#nullable disable
        internal MessageEntityPre() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
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

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}