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
	public partial class GetEmojiKeywordsLanguages : IMethod
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1318675378; }
        
[Newtonsoft.Json.JsonIgnore]
		ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

[Newtonsoft.Json.JsonProperty("lang_codes")]
		public List<string> LangCodes { get; set; }

        
        #nullable enable
 public GetEmojiKeywordsLanguages (List<string> langCodes)
{
 LangCodes = langCodes;
 
}
#nullable disable
                
        internal GetEmojiKeywordsLanguages() 
        {
        }
        
		public void UpdateFlags() 
		{

		}

		public WriteResult Serialize(Writer writer)
		{
writer.WriteInt32(ConstructorId);

			writer.WriteVector(LangCodes, false);

return new WriteResult();

		}

		public ReadResult<IObject> Deserialize(Reader reader)
		{
			var trylangCodes = reader.ReadVector<string>(ParserTypes.String, nakedVector: false, nakedObjects: false);
if(trylangCodes.IsError){
return ReadResult<IObject>.Move(trylangCodes);
}
LangCodes = trylangCodes.Value;
return new ReadResult<IObject>(this);

		}

		public override string ToString()
		{
		    return "messages.getEmojiKeywordsLanguages";
		}

		public int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}