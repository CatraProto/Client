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
	public partial class PageListItemText : CatraProto.Client.TL.Schemas.CloudChats.PageListItemBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1188055347; }
        
[Newtonsoft.Json.JsonProperty("text")]
		public CatraProto.Client.TL.Schemas.CloudChats.RichTextBase Text { get; set; }


        #nullable enable
 public PageListItemText (CatraProto.Client.TL.Schemas.CloudChats.RichTextBase text)
{
 Text = text;
 
}
#nullable disable
        internal PageListItemText() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override WriteResult Serialize(Writer writer)
		{
writer.WriteInt32(ConstructorId);
var checktext = 			writer.WriteObject(Text);
if(checktext.IsError){
 return checktext; 
}

return new WriteResult();

		}

		public override ReadResult<IObject> Deserialize(Reader reader)
		{
			var trytext = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.RichTextBase>();
if(trytext.IsError){
return ReadResult<IObject>.Move(trytext);
}
Text = trytext.Value;
return new ReadResult<IObject>(this);

		}
		
		public override string ToString()
		{
		    return "pageListItemText";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}