using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class MessageInteractionCounters : CatraProto.Client.TL.Schemas.CloudChats.MessageInteractionCountersBase
	{


        public static int StaticConstructorId { get => -1387279939; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("msg_id")]
		public override int MsgId { get; set; }

[JsonPropertyName("views")]
		public override int Views { get; set; }

[JsonPropertyName("forwards")]
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
	}
}