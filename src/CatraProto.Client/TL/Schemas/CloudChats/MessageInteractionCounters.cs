using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class MessageInteractionCounters : CatraProto.Client.TL.Schemas.CloudChats.MessageInteractionCountersBase
	{


        public static int StaticConstructorId { get => -1387279939; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("msg_id")]
		public override int MsgId { get; set; }

[Newtonsoft.Json.JsonProperty("views")]
		public override int Views { get; set; }

[Newtonsoft.Json.JsonProperty("forwards")]
		public override int Forwards { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(MsgId);
			writer.Write(Views);
			writer.Write(Forwards);

		}

		public override void Deserialize(Reader reader)
		{
			MsgId = reader.Read<int>();
			Views = reader.Read<int>();
			Forwards = reader.Read<int>();

		}
				
		public override string ToString()
		{
		    return "messageInteractionCounters";
		}
	}
}