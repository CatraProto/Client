using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class MessageEntityMentionName : CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -595914432; }
        
[Newtonsoft.Json.JsonProperty("offset")]
		public sealed override int Offset { get; set; }

[Newtonsoft.Json.JsonProperty("length")]
		public sealed override int Length { get; set; }

[Newtonsoft.Json.JsonProperty("user_id")]
		public long UserId { get; set; }


        #nullable enable
 public MessageEntityMentionName (int offset,int length,long userId)
{
 Offset = offset;
Length = length;
UserId = userId;
 
}
#nullable disable
        internal MessageEntityMentionName() 
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
			UserId = reader.Read<long>();

		}
		
		public override string ToString()
		{
		    return "messageEntityMentionName";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}