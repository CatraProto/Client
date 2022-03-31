using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputGeoPointEmpty : CatraProto.Client.TL.Schemas.CloudChats.InputGeoPointBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -457104426; }
        

        
        public InputGeoPointEmpty() 
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
		    return "inputGeoPointEmpty";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}