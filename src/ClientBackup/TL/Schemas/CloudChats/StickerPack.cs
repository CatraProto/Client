using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class StickerPack : CatraProto.Client.TL.Schemas.CloudChats.StickerPackBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 313694676; }
        
[Newtonsoft.Json.JsonProperty("emoticon")]
		public sealed override string Emoticon { get; set; }

[Newtonsoft.Json.JsonProperty("documents")]
		public sealed override List<long> Documents { get; set; }


        #nullable enable
 public StickerPack (string emoticon,List<long> documents)
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

		public override WriteResult Serialize(Writer writer)
		{
writer.WriteInt32(ConstructorId);

			writer.WriteString(Emoticon);

			writer.WriteVector(Documents, false);

return new WriteResult();

		}

		public override ReadResult<IObject> Deserialize(Reader reader)
		{
			var tryemoticon = reader.ReadString();
if(tryemoticon.IsError){
return ReadResult<IObject>.Move(tryemoticon);
}
Emoticon = tryemoticon.Value;
			var trydocuments = reader.ReadVector<long>(ParserTypes.Int64);
if(trydocuments.IsError){
return ReadResult<IObject>.Move(trydocuments);
}
Documents = trydocuments.Value;
return new ReadResult<IObject>(this);

		}
		
		public override string ToString()
		{
		    return "stickerPack";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}