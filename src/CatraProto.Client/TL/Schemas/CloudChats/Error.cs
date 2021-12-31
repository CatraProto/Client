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
		public override int Code { get; set; }

[Newtonsoft.Json.JsonProperty("text")]
		public override string Text { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
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