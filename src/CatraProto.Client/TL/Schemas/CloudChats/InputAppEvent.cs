using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputAppEvent : CatraProto.Client.TL.Schemas.CloudChats.InputAppEventBase
	{


        public static int StaticConstructorId { get => 488313413; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("time")]
		public override double Time { get; set; }

[Newtonsoft.Json.JsonProperty("type")]
		public override string Type { get; set; }

[Newtonsoft.Json.JsonProperty("peer")]
		public override long Peer { get; set; }

[Newtonsoft.Json.JsonProperty("data")]
		public override CatraProto.Client.TL.Schemas.CloudChats.JSONValueBase Data { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Time);
			writer.Write(Type);
			writer.Write(Peer);
			writer.Write(Data);

		}

		public override void Deserialize(Reader reader)
		{
			Time = reader.Read<double>();
			Type = reader.Read<string>();
			Peer = reader.Read<long>();
			Data = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.JSONValueBase>();

		}
				
		public override string ToString()
		{
		    return "inputAppEvent";
		}
	}
}