using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class MessageMediaDice : CatraProto.Client.TL.Schemas.CloudChats.MessageMediaBase
	{


        public static int StaticConstructorId { get => 1065280907; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("value")]
		public int Value { get; set; }

[Newtonsoft.Json.JsonProperty("emoticon")]
		public string Emoticon { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Value);
			writer.Write(Emoticon);

		}

		public override void Deserialize(Reader reader)
		{
			Value = reader.Read<int>();
			Emoticon = reader.Read<string>();

		}
				
		public override string ToString()
		{
		    return "messageMediaDice";
		}
	}
}