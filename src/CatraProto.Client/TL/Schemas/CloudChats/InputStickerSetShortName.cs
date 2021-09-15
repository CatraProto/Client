using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputStickerSetShortName : CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetBase
	{


        public static int StaticConstructorId { get => -2044933984; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("short_name")]
		public string ShortName { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(ShortName);

		}

		public override void Deserialize(Reader reader)
		{
			ShortName = reader.Read<string>();

		}
				
		public override string ToString()
		{
		    return "inputStickerSetShortName";
		}
	}
}