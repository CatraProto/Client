using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdateBotStopped : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -997782967; }
        
[Newtonsoft.Json.JsonProperty("user_id")]
		public long UserId { get; set; }

[Newtonsoft.Json.JsonProperty("date")]
		public int Date { get; set; }

[Newtonsoft.Json.JsonProperty("stopped")]
		public bool Stopped { get; set; }

[Newtonsoft.Json.JsonProperty("qts")]
		public int Qts { get; set; }


        #nullable enable
 public UpdateBotStopped (long userId,int date,bool stopped,int qts)
{
 UserId = userId;
Date = date;
Stopped = stopped;
Qts = qts;
 
}
#nullable disable
        internal UpdateBotStopped() 
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
			writer.Write(Stopped);
			writer.Write(Qts);

		}

		public override void Deserialize(Reader reader)
		{
			UserId = reader.Read<long>();
			Date = reader.Read<int>();
			Stopped = reader.Read<bool>();
			Qts = reader.Read<int>();

		}
		
		public override string ToString()
		{
		    return "updateBotStopped";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}