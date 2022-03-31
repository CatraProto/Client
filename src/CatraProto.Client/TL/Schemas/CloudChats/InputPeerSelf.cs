using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputPeerSelf : CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 2107670217; }
        

        
        public InputPeerSelf() 
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
		    return "inputPeerSelf";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}