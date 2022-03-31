using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class MessageEntityBold : CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1117713463; }
        
[Newtonsoft.Json.JsonProperty("offset")]
		public sealed override int Offset { get; set; }

[Newtonsoft.Json.JsonProperty("length")]
		public sealed override int Length { get; set; }


        #nullable enable
 public MessageEntityBold (int offset,int length)
{
 Offset = offset;
Length = length;
 
}
#nullable disable
        internal MessageEntityBold() 
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

		}

		public override void Deserialize(Reader reader)
		{
			Offset = reader.Read<int>();
			Length = reader.Read<int>();

		}
		
		public override string ToString()
		{
		    return "messageEntityBold";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}