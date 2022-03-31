using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputStickerSetAnimatedEmoji : CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 42402760; }
        

        
        public InputStickerSetAnimatedEmoji() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);

		}

		public override void Deserialize(Reader reader)
		{

		}
		
		public override string ToString()
		{
		    return "inputStickerSetAnimatedEmoji";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}