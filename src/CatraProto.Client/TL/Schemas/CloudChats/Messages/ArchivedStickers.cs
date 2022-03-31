using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class ArchivedStickers : CatraProto.Client.TL.Schemas.CloudChats.Messages.ArchivedStickersBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1338747336; }
        
[Newtonsoft.Json.JsonProperty("count")]
		public sealed override int Count { get; set; }

[Newtonsoft.Json.JsonProperty("sets")]
		public sealed override IList<CatraProto.Client.TL.Schemas.CloudChats.StickerSetCoveredBase> Sets { get; set; }


        #nullable enable
 public ArchivedStickers (int count,IList<CatraProto.Client.TL.Schemas.CloudChats.StickerSetCoveredBase> sets)
{
 Count = count;
Sets = sets;
 
}
#nullable disable
        internal ArchivedStickers() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Count);
			writer.Write(Sets);

		}

		public override void Deserialize(Reader reader)
		{
			Count = reader.Read<int>();
			Sets = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.StickerSetCoveredBase>();

		}
		
		public override string ToString()
		{
		    return "messages.archivedStickers";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}