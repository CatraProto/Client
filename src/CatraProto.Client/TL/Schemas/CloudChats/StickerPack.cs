using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class StickerPack : CatraProto.Client.TL.Schemas.CloudChats.StickerPackBase
	{


        public static int StaticConstructorId { get => 313694676; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("emoticon")]
		public sealed override string Emoticon { get; set; }

[Newtonsoft.Json.JsonProperty("documents")]
		public sealed override IList<long> Documents { get; set; }


        #nullable enable
 public StickerPack (string emoticon,IList<long> documents)
{
 Emoticon = emoticon;
Documents = documents;
 
}
#nullable disable
        internal StickerPack() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Emoticon);
			writer.Write(Documents);

		}

		public override void Deserialize(Reader reader)
		{
			Emoticon = reader.Read<string>();
			Documents = reader.ReadVector<long>();

		}
				
		public override string ToString()
		{
		    return "stickerPack";
		}
	}
}