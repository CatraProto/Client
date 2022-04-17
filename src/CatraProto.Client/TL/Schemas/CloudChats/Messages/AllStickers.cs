using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class AllStickers : CatraProto.Client.TL.Schemas.CloudChats.Messages.AllStickersBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -843329861; }
        
[Newtonsoft.Json.JsonProperty("hash")]
		public long Hash { get; set; }

[Newtonsoft.Json.JsonProperty("sets")]
		public List<CatraProto.Client.TL.Schemas.CloudChats.StickerSetBase> Sets { get; set; }


        #nullable enable
 public AllStickers (long hash,List<CatraProto.Client.TL.Schemas.CloudChats.StickerSetBase> sets)
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

		public override WriteResult Serialize(Writer writer)
		{
writer.WriteInt32(ConstructorId);
writer.WriteInt64(Hash);
var checksets = 			writer.WriteVector(Sets, false);
if(checksets.IsError){
 return checksets; 
}

return new WriteResult();

		}

		public override ReadResult<IObject> Deserialize(Reader reader)
		{
			var tryhash = reader.ReadInt64();
if(tryhash.IsError){
return ReadResult<IObject>.Move(tryhash);
}
Hash = tryhash.Value;
			var trysets = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.StickerSetBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
if(trysets.IsError){
return ReadResult<IObject>.Move(trysets);
}
Sets = trysets.Value;
return new ReadResult<IObject>(this);

		}
		
		public override string ToString()
		{
		    return "messages.allStickers";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}