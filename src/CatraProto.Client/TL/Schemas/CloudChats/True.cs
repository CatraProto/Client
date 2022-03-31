using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class True : CatraProto.Client.TL.Schemas.CloudChats.TrueBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1072550713; }
        

        
        public True() 
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
		    return "true";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}