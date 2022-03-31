using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputMediaEmpty : CatraProto.Client.TL.Schemas.CloudChats.InputMediaBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1771768449; }
        

        
        public InputMediaEmpty() 
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
		    return "inputMediaEmpty";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}