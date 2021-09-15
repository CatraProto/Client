using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class PollAnswer : CatraProto.Client.TL.Schemas.CloudChats.PollAnswerBase
	{


        public static int StaticConstructorId { get => 1823064809; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("text")]
		public override string Text { get; set; }

[Newtonsoft.Json.JsonProperty("option")]
		public override byte[] Option { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Text);
			writer.Write(Option);

		}

		public override void Deserialize(Reader reader)
		{
			Text = reader.Read<string>();
			Option = reader.Read<byte[]>();

		}
				
		public override string ToString()
		{
		    return "pollAnswer";
		}
	}
}