using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputReportReasonSpam : CatraProto.Client.TL.Schemas.CloudChats.ReportReasonBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1490799288; }
        

        
        public InputReportReasonSpam() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);

		}

		public override void Deserialize(Reader reader)
		{

		}
		
		public override string ToString()
		{
		    return "inputReportReasonSpam";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}