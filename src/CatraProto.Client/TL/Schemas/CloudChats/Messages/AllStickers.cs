using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class AllStickers : CatraProto.Client.TL.Schemas.CloudChats.Messages.AllStickersBase
	{


        public static int StaticConstructorId { get => -843329861; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("hash")]
		public long Hash { get; set; }

[Newtonsoft.Json.JsonProperty("sets")]
		public IList<CatraProto.Client.TL.Schemas.CloudChats.StickerSetBase> Sets { get; set; }


        #nullable enable
 public AllStickers (long hash,IList<CatraProto.Client.TL.Schemas.CloudChats.StickerSetBase> sets)
{
 Hash = hash;
Sets = sets;
 
}
#nullable disable
        internal AllStickers() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Hash);
			writer.Write(Sets);

		}

		public override void Deserialize(Reader reader)
		{
			Hash = reader.Read<long>();
			Sets = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.StickerSetBase>();

		}
				
		public override string ToString()
		{
		    return "messages.allStickers";
		}
	}
}