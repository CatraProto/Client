using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Updates
{
	public partial class State : CatraProto.Client.TL.Schemas.CloudChats.Updates.StateBase
	{


        public static int StaticConstructorId { get => -1519637954; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("pts")]
		public sealed override int Pts { get; set; }

[Newtonsoft.Json.JsonProperty("qts")]
		public sealed override int Qts { get; set; }

[Newtonsoft.Json.JsonProperty("date")]
		public sealed override int Date { get; set; }

[Newtonsoft.Json.JsonProperty("seq")]
		public sealed override int Seq { get; set; }

[Newtonsoft.Json.JsonProperty("unread_count")]
		public sealed override int UnreadCount { get; set; }


        #nullable enable
 public State (int pts,int qts,int date,int seq,int unreadCount)
{
 Pts = pts;
Qts = qts;
Date = date;
Seq = seq;
UnreadCount = unreadCount;
 
}
#nullable disable
        internal State() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Pts);
			writer.Write(Qts);
			writer.Write(Date);
			writer.Write(Seq);
			writer.Write(UnreadCount);

		}

		public override void Deserialize(Reader reader)
		{
			Pts = reader.Read<int>();
			Qts = reader.Read<int>();
			Date = reader.Read<int>();
			Seq = reader.Read<int>();
			UnreadCount = reader.Read<int>();

		}
				
		public override string ToString()
		{
		    return "updates.state";
		}
	}
}