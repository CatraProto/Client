using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputMediaDice : CatraProto.Client.TL.Schemas.CloudChats.InputMediaBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -428884101; }
        
[Newtonsoft.Json.JsonProperty("emoticon")]
		public string Emoticon { get; set; }


        #nullable enable
 public InputMediaDice (string emoticon)
{
 Emoticon = emoticon;
 
}
#nullable disable
        internal InputMediaDice() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Emoticon);

		}

		public override void Deserialize(Reader reader)
		{
			Emoticon = reader.Read<string>();

		}
		
		public override string ToString()
		{
		    return "inputMediaDice";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}