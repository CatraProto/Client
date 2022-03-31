using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class MessageUserVoteInputOption : CatraProto.Client.TL.Schemas.CloudChats.MessageUserVoteBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1017491692; }
        
[Newtonsoft.Json.JsonProperty("user_id")]
		public sealed override long UserId { get; set; }

[Newtonsoft.Json.JsonProperty("date")]
		public sealed override int Date { get; set; }


        #nullable enable
 public MessageUserVoteInputOption (long userId,int date)
{
 UserId = userId;
Date = date;
 
}
#nullable disable
        internal MessageUserVoteInputOption() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(UserId);
			writer.Write(Date);

		}

		public override void Deserialize(Reader reader)
		{
			UserId = reader.Read<long>();
			Date = reader.Read<int>();

		}
		
		public override string ToString()
		{
		    return "messageUserVoteInputOption";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}