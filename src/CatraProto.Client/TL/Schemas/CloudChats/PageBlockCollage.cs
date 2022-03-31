using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class PageBlockCollage : CatraProto.Client.TL.Schemas.CloudChats.PageBlockBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1705048653; }
        
[Newtonsoft.Json.JsonProperty("items")]
		public IList<CatraProto.Client.TL.Schemas.CloudChats.PageBlockBase> Items { get; set; }

[Newtonsoft.Json.JsonProperty("caption")]
		public CatraProto.Client.TL.Schemas.CloudChats.PageCaptionBase Caption { get; set; }


        #nullable enable
 public PageBlockCollage (IList<CatraProto.Client.TL.Schemas.CloudChats.PageBlockBase> items,CatraProto.Client.TL.Schemas.CloudChats.PageCaptionBase caption)
{
 Items = items;
Caption = caption;
 
}
#nullable disable
        internal PageBlockCollage() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Items);
			writer.Write(Caption);

		}

		public override void Deserialize(Reader reader)
		{
			Items = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.PageBlockBase>();
			Caption = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.PageCaptionBase>();

		}
		
		public override string ToString()
		{
		    return "pageBlockCollage";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}