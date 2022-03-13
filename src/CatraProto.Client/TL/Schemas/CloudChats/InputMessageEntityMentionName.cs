using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputMessageEntityMentionName : CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase
	{


        public static int StaticConstructorId { get => 546203849; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("offset")]
		public sealed override int Offset { get; set; }

[Newtonsoft.Json.JsonProperty("length")]
		public sealed override int Length { get; set; }

[Newtonsoft.Json.JsonProperty("user_id")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputUserBase UserId { get; set; }


        #nullable enable
 public InputMessageEntityMentionName (int offset,int length,CatraProto.Client.TL.Schemas.CloudChats.InputUserBase userId)
{
 Offset = offset;
Length = length;
UserId = userId;
 
}
#nullable disable
        internal InputMessageEntityMentionName() 
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
			writer.Write(UserId);

		}

		public override void Deserialize(Reader reader)
		{
			Offset = reader.Read<int>();
			Length = reader.Read<int>();
			UserId = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputUserBase>();

		}
				
		public override string ToString()
		{
		    return "inputMessageEntityMentionName";
		}
	}
}