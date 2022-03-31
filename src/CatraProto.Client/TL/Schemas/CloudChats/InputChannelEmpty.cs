using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputChannelEmpty : CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -292807034; }
        

        
        public InputChannelEmpty() 
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
		    return "inputChannelEmpty";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}