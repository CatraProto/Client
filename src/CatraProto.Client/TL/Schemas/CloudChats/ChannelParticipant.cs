using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class ChannelParticipant : CatraProto.Client.TL.Schemas.CloudChats.ChannelParticipantBase
	{


        public static int StaticConstructorId { get => -1072953408; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("user_id")]
		public long UserId { get; set; }

[Newtonsoft.Json.JsonProperty("date")]
		public int Date { get; set; }


        #nullable enable
 public ChannelParticipant (long userId,int date)
{
 UserId = userId;
Date = date;
 
}
#nullable disable
        internal ChannelParticipant() 
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
		    return "channelParticipant";
		}
	}
}