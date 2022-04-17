using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class MessageUserVote : CatraProto.Client.TL.Schemas.CloudChats.MessageUserVoteBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 886196148; }
        
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

		public override WriteResult Serialize(Writer writer)
		{
writer.WriteInt32(ConstructorId);
writer.WriteInt64(UserId);

			writer.WriteBytes(Option);
writer.WriteInt32(Date);

return new WriteResult();

		}

		public override ReadResult<IObject> Deserialize(Reader reader)
		{
			var tryuserId = reader.ReadInt64();
if(tryuserId.IsError){
return ReadResult<IObject>.Move(tryuserId);
}
UserId = tryuserId.Value;
			var tryoption = reader.ReadBytes();
if(tryoption.IsError){
return ReadResult<IObject>.Move(tryoption);
}
Option = tryoption.Value;
			var trydate = reader.ReadInt32();
if(trydate.IsError){
return ReadResult<IObject>.Move(trydate);
}
Date = trydate.Value;
return new ReadResult<IObject>(this);

		}
		
		public override string ToString()
		{
		    return "messageUserVote";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}