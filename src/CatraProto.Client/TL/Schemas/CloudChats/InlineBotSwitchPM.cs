using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InlineBotSwitchPM : CatraProto.Client.TL.Schemas.CloudChats.InlineBotSwitchPMBase
	{


        public static int StaticConstructorId { get => 1008755359; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("text")]
		public sealed override string Text { get; set; }

[Newtonsoft.Json.JsonProperty("start_param")]
		public sealed override string StartParam { get; set; }


        #nullable enable
 public InlineBotSwitchPM (string text,string startParam)
{
 Text = text;
StartParam = startParam;
 
}
#nullable disable
        internal InlineBotSwitchPM() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Text);
			writer.Write(StartParam);

		}

		public override void Deserialize(Reader reader)
		{
			Text = reader.Read<string>();
			StartParam = reader.Read<string>();

		}
				
		public override string ToString()
		{
		    return "inlineBotSwitchPM";
		}
	}
}