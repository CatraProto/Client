using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class RestrictionReason : CatraProto.Client.TL.Schemas.CloudChats.RestrictionReasonBase
	{


        public static int StaticConstructorId { get => -797791052; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("platform")]
		public override string Platform { get; set; }

[Newtonsoft.Json.JsonProperty("reason")]
		public override string Reason { get; set; }

[Newtonsoft.Json.JsonProperty("text")]
		public override string Text { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Platform);
			writer.Write(Reason);
			writer.Write(Text);

		}

		public override void Deserialize(Reader reader)
		{
			Platform = reader.Read<string>();
			Reason = reader.Read<string>();
			Text = reader.Read<string>();

		}
				
		public override string ToString()
		{
		    return "restrictionReason";
		}
	}
}