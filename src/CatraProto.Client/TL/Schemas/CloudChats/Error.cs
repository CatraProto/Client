using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class Error : CatraProto.Client.TL.Schemas.CloudChats.ErrorBase
	{


        public static int StaticConstructorId { get => -994444869; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
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

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Code);
			writer.Write(Text);

		}

		public override void Deserialize(Reader reader)
		{
			Code = reader.Read<int>();
			Text = reader.Read<string>();

		}
				
		public override string ToString()
		{
		    return "error";
		}
	}
}