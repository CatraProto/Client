using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class PageBlockList : CatraProto.Client.TL.Schemas.CloudChats.PageBlockBase
	{


        public static int StaticConstructorId { get => -454524911; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("items")]
		public IList<CatraProto.Client.TL.Schemas.CloudChats.PageListItemBase> Items { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Items);

		}

		public override void Deserialize(Reader reader)
		{
			Items = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.PageListItemBase>();

		}
	}
}