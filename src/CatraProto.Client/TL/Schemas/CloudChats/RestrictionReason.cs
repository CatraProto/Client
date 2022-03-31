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


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -797791052; }
        
[Newtonsoft.Json.JsonProperty("platform")]
		public sealed override string Platform { get; set; }

[Newtonsoft.Json.JsonProperty("reason")]
		public sealed override string Reason { get; set; }

[Newtonsoft.Json.JsonProperty("text")]
		public sealed override string Text { get; set; }


        #nullable enable
 public RestrictionReason (string platform,string reason,string text)
{
 Platform = platform;
Reason = reason;
Text = text;
 
}
#nullable disable
        internal RestrictionReason() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
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

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}