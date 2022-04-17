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
	public partial class Error : CatraProto.Client.TL.Schemas.CloudChats.ErrorBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -994444869; }
        
[Newtonsoft.Json.JsonProperty("code")]
		public sealed override int Code { get; set; }

[Newtonsoft.Json.JsonProperty("text")]
		public sealed override string Text { get; set; }


        #nullable enable
 public Error (int code,string text)
{
 Code = code;
Text = text;
 
}
#nullable disable
        internal Error() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override WriteResult Serialize(Writer writer)
		{
writer.WriteInt32(ConstructorId);
writer.WriteInt32(Code);

			writer.WriteString(Text);

return new WriteResult();

		}

		public override ReadResult<IObject> Deserialize(Reader reader)
		{
			var trycode = reader.ReadInt32();
if(trycode.IsError){
return ReadResult<IObject>.Move(trycode);
}
Code = trycode.Value;
			var trytext = reader.ReadString();
if(trytext.IsError){
return ReadResult<IObject>.Move(trytext);
}
Text = trytext.Value;
return new ReadResult<IObject>(this);

		}
		
		public override string ToString()
		{
		    return "error";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}