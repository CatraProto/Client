using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputReportReasonChildAbuse : CatraProto.Client.TL.Schemas.CloudChats.ReportReasonBase
	{


        public static int StaticConstructorId { get => -1376497949; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);

		}

		public override void Deserialize(Reader reader)
		{

		}
				
		public override string ToString()
		{
		    return "inputReportReasonChildAbuse";
		}
	}
}