using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class StickerSetMultiCovered : CatraProto.Client.TL.Schemas.CloudChats.StickerSetCoveredBase
	{


        public static int StaticConstructorId { get => 872932635; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("set")]
		public sealed override CatraProto.Client.TL.Schemas.CloudChats.StickerSetBase Set { get; set; }

[Newtonsoft.Json.JsonProperty("covers")]
		public IList<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase> Covers { get; set; }


        #nullable enable
 public StickerSetMultiCovered (CatraProto.Client.TL.Schemas.CloudChats.StickerSetBase set,IList<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase> covers)
{
 Set = set;
Covers = covers;
 
}
#nullable disable
        internal StickerSetMultiCovered() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Set);
			writer.Write(Covers);

		}

		public override void Deserialize(Reader reader)
		{
			Set = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.StickerSetBase>();
			Covers = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase>();

		}
				
		public override string ToString()
		{
		    return "stickerSetMultiCovered";
		}
	}
}