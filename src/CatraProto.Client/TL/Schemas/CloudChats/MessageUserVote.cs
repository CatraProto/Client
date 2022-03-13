using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class MessageUserVote : CatraProto.Client.TL.Schemas.CloudChats.MessageUserVoteBase
	{


        public static int StaticConstructorId { get => 886196148; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("user_id")]
		public sealed override long UserId { get; set; }

[Newtonsoft.Json.JsonProperty("option")]
		public byte[] Option { get; set; }

[Newtonsoft.Json.JsonProperty("date")]
		public sealed override int Date { get; set; }


        #nullable enable
 public MessageUserVote (long userId,byte[] option,int date)
{
 UserId = userId;
Option = option;
Date = date;
 
}
#nullable disable
        internal MessageUserVote() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(UserId);
			writer.Write(Option);
			writer.Write(Date);

		}

		public override void Deserialize(Reader reader)
		{
			UserId = reader.Read<long>();
			Option = reader.Read<byte[]>();
			Date = reader.Read<int>();

		}
				
		public override string ToString()
		{
		    return "messageUserVote";
		}
	}
}