using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputTakeoutFileLocation : CatraProto.Client.TL.Schemas.CloudChats.InputFileLocationBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 700340377; }
        

        
        public InputTakeoutFileLocation() 
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
		    return "inputTakeoutFileLocation";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}