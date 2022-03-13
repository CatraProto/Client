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


        #nullable enable
 public MessageMediaDice (int value,string emoticon)
{
 Value = value;
Emoticon = emoticon;
 
}
#nullable disable
        internal MessageMediaDice() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
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