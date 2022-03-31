using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputReportReasonCopyright : CatraProto.Client.TL.Schemas.CloudChats.ReportReasonBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1685456582; }
        

        
        public InputReportReasonCopyright() 
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
		    return "inputReportReasonCopyright";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}