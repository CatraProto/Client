using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Stickers
{
	public partial class RemoveStickerFromSet : IMethod
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId { get => -143257775; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Messages.StickerSetBase);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonProperty("sticker")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputDocumentBase Sticker { get; set; }


		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Sticker);

		}

		public void Deserialize(Reader reader)
		{
			Sticker = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputDocumentBase>();

		}
		
		public override string ToString()
		{
		    return "stickers.removeStickerFromSet";
		}
	}
}