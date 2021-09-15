using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputReportReasonOther : CatraProto.Client.TL.Schemas.CloudChats.ReportReasonBase
	{


        public static int StaticConstructorId { get => -512463606; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("text")]
		public string Text { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Text);

		}

		public override void Deserialize(Reader reader)
		{
			Text = reader.Read<string>();

		}
				
		public override string ToString()
		{
		    return "inputReportReasonOther";
		}
	}
}