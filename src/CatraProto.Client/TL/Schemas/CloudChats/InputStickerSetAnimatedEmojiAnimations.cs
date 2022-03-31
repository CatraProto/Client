using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputStickerSetAnimatedEmojiAnimations : CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 215889721; }
        

        
        public InputStickerSetAnimatedEmojiAnimations() 
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
		    return "inputStickerSetAnimatedEmojiAnimations";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}