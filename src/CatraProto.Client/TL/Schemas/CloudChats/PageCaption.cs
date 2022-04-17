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
	public partial class PageCaption : CatraProto.Client.TL.Schemas.CloudChats.PageCaptionBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1869903447; }
        
[Newtonsoft.Json.JsonProperty("text")]
		public sealed override CatraProto.Client.TL.Schemas.CloudChats.RichTextBase Text { get; set; }

[Newtonsoft.Json.JsonProperty("credit")]
		public sealed override CatraProto.Client.TL.Schemas.CloudChats.RichTextBase Credit { get; set; }


        #nullable enable
 public PageCaption (CatraProto.Client.TL.Schemas.CloudChats.RichTextBase text,CatraProto.Client.TL.Schemas.CloudChats.RichTextBase credit)
{
 Text = text;
Credit = credit;
 
}
#nullable disable
        internal PageCaption() 
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
var checkcredit = 			writer.WriteObject(Credit);
if(checkcredit.IsError){
 return checkcredit; 
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
			var trycredit = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.RichTextBase>();
if(trycredit.IsError){
return ReadResult<IObject>.Move(trycredit);
}
Credit = trycredit.Value;
return new ReadResult<IObject>(this);

		}
		
		public override string ToString()
		{
		    return "pageCaption";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}