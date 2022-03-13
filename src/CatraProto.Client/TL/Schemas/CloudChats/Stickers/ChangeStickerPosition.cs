using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Stickers
{
	public partial class ChangeStickerPosition : IMethod
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId { get => -4795190; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Messages.StickerSetBase);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonProperty("sticker")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputDocumentBase Sticker { get; set; }

[Newtonsoft.Json.JsonProperty("position")]
		public int Position { get; set; }

        
        #nullable enable
 public ChangeStickerPosition (CatraProto.Client.TL.Schemas.CloudChats.InputDocumentBase sticker,int position)
{
 Sticker = sticker;
Position = position;
 
}
#nullable disable
                
        internal ChangeStickerPosition() 
        {
        }
        
		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Sticker);
			writer.Write(Position);

		}

		public void Deserialize(Reader reader)
		{
			Sticker = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputDocumentBase>();
			Position = reader.Read<int>();

		}
		
		public override string ToString()
		{
		    return "stickers.changeStickerPosition";
		}
	}
}