using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputStickerSetDice : CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -427863538; }
        
[Newtonsoft.Json.JsonProperty("emoticon")]
		public string Emoticon { get; set; }


        #nullable enable
 public InputStickerSetDice (string emoticon)
{
 Emoticon = emoticon;
 
}
#nullable disable
        internal InputStickerSetDice() 
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
		    return "inputStickerSetDice";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}